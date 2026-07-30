using CafeManager.WinForms.Controls;
using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Forms;

public sealed class ReportsForm : Form
{
    private readonly DateTimePicker _from = new() { Width = 130, Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddDays(-6) };
    private readonly DateTimePicker _to = new() { Width = 130, Format = DateTimePickerFormat.Short, Value = DateTime.Today };
    private readonly Label _todayRevenue = SummaryLabel("Hôm nay\n0 đ");
    private readonly Label _monthRevenue = SummaryLabel("Tháng này\n0 đ");
    private readonly Label _yearRevenue = SummaryLabel("Năm nay\n0 đ");
    private readonly Label _openTables = SummaryLabel("Bàn phục vụ\n0");
    private readonly DataGridView _revenueGrid = Ui.Grid();
    private readonly DataGridView _topProductsGrid = Ui.Grid();
    private readonly RevenueChart _chart = new() { Dock = DockStyle.Fill };
    private List<RevenueExportRow> _currentRows = [];

    public ReportsForm()
    {
        Text = "Thống kê và Dashboard";

        var toolbar = Ui.Row(
            Ui.Label("Từ ngày", 70), _from,
            Ui.Label("Đến ngày", 80), _to,
            Ui.Button("Thống kê", (_, _) => LoadReports(), 100),
            Ui.Button("Xuất Excel", (_, _) => ExportExcel(), 110));

        var cards = new TableLayoutPanel { Dock = DockStyle.Top, Height = 105, ColumnCount = 4, Padding = new Padding(6) };
        for (int i = 0; i < 4; i++) cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
        cards.Controls.Add(_todayRevenue, 0, 0);
        cards.Controls.Add(_monthRevenue, 1, 0);
        cards.Controls.Add(_yearRevenue, 2, 0);
        cards.Controls.Add(_openTables, 3, 0);

        var tabs = new TabControl { Dock = DockStyle.Fill, Font = Ui.NormalFont };
        var dashboardTab = new TabPage("Dashboard biểu đồ");
        dashboardTab.Controls.Add(_chart);
        var revenueTab = new TabPage("Doanh thu theo ngày");
        revenueTab.Controls.Add(_revenueGrid);
        var topTab = new TabPage("Món bán chạy");
        topTab.Controls.Add(_topProductsGrid);
        tabs.TabPages.AddRange([dashboardTab, revenueTab, topTab]);

        Controls.Add(tabs);
        Controls.Add(cards);
        Controls.Add(toolbar);
        Load += (_, _) => LoadReports();
    }

    private static Label SummaryLabel(string text) => new()
    {
        Text = text,
        Dock = DockStyle.Fill,
        Margin = new Padding(8),
        BorderStyle = BorderStyle.FixedSingle,
        Font = new Font("Segoe UI Semibold", 14F),
        TextAlign = ContentAlignment.MiddleCenter,
        BackColor = Color.WhiteSmoke
    };

    private void LoadReports()
    {
        DateTime from = _from.Value.Date;
        DateTime toExclusive = _to.Value.Date.AddDays(1);
        if (from >= toExclusive)
        {
            Ui.Error("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
            return;
        }

        using var db = new CafeDbContext();
        var allPaid = db.Invoices.AsNoTracking()
            .Where(x => x.Status == InvoiceStatus.Paid && x.PaidAt != null)
            .Select(x => new { x.Id, x.PaidAt, x.Total })
            .ToList();

        DateTime today = DateTime.Today;
        decimal todayValue = allPaid.Where(x => x.PaidAt >= today && x.PaidAt < today.AddDays(1)).Sum(x => x.Total);
        DateTime monthStart = new(today.Year, today.Month, 1);
        decimal monthValue = allPaid.Where(x => x.PaidAt >= monthStart && x.PaidAt < monthStart.AddMonths(1)).Sum(x => x.Total);
        DateTime yearStart = new(today.Year, 1, 1);
        decimal yearValue = allPaid.Where(x => x.PaidAt >= yearStart && x.PaidAt < yearStart.AddYears(1)).Sum(x => x.Total);
        int servingTables = db.CafeTables.Count(x => x.Status == TableStatus.Serving);

        _todayRevenue.Text = $"Hôm nay\n{Ui.Money(todayValue)}";
        _monthRevenue.Text = $"Tháng này\n{Ui.Money(monthValue)}";
        _yearRevenue.Text = $"Năm nay\n{Ui.Money(yearValue)}";
        _openTables.Text = $"Bàn phục vụ\n{servingTables}";

        var rangeInvoices = allPaid
            .Where(x => x.PaidAt >= from && x.PaidAt < toExclusive)
            .ToList();
        var daily = rangeInvoices
            .GroupBy(x => x.PaidAt!.Value.Date)
            .OrderBy(x => x.Key)
            .Select(x => new RevenueDay(x.Key, x.Count(), x.Sum(i => i.Total)))
            .ToList();

        _revenueGrid.DataSource = daily.Select(x => new
        {
            Ngay = x.Date.ToString("dd/MM/yyyy"),
            SoHoaDon = x.InvoiceCount,
            DoanhThu = x.Revenue
        }).ToList();
        if (_revenueGrid.Columns["DoanhThu"] is not null) _revenueGrid.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";

        _currentRows = daily.Select(x => new RevenueExportRow(x.Date.ToString("dd/MM/yyyy"), x.InvoiceCount, x.Revenue)).ToList();
        _chart.SetData(daily.Select(x => new RevenuePoint(x.Date.ToString("dd/MM"), x.Revenue)));

        var details = db.InvoiceDetails.AsNoTracking()
            .Include(x => x.Product)
            .Include(x => x.Invoice)
            .Where(x => x.Invoice != null && x.Invoice.Status == InvoiceStatus.Paid && x.Invoice.PaidAt >= from && x.Invoice.PaidAt < toExclusive)
            .Select(x => new
            {
                ProductName = x.Product != null ? x.Product.Name : "Không xác định",
                x.Quantity,
                Revenue = x.Quantity * x.UnitPrice
            }).ToList();

        _topProductsGrid.DataSource = details
            .GroupBy(x => x.ProductName)
            .Select(x => new { TenMon = x.Key, SoLuongBan = x.Sum(i => i.Quantity), DoanhThu = x.Sum(i => i.Revenue) })
            .OrderByDescending(x => x.SoLuongBan)
            .ThenByDescending(x => x.DoanhThu)
            .Take(20)
            .ToList();
        if (_topProductsGrid.Columns["DoanhThu"] is not null) _topProductsGrid.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
    }

    private void ExportExcel()
    {
        if (_currentRows.Count == 0)
        {
            Ui.Error("Không có dữ liệu để xuất.");
            return;
        }
        using var dialog = new SaveFileDialog
        {
            Filter = "Excel 2003 XML (*.xls)|*.xls",
            FileName = $"DoanhThu_{_from.Value:yyyyMMdd}_{_to.Value:yyyyMMdd}.xls"
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        ExcelXmlExporter.ExportRevenue(dialog.FileName, _currentRows, _from.Value.Date, _to.Value.Date);
        Ui.Info("Xuất Excel thành công.");
    }

    private sealed record RevenueDay(DateTime Date, int InvoiceCount, decimal Revenue);
}
