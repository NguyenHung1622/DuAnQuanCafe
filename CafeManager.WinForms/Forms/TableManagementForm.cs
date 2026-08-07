using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Forms;

public sealed partial class TableManagementForm : Form
{
    private int? _selectedId;

    public TableManagementForm()
    {
        InitializeComponent();
        _status.DataSource = Enum.GetValues<TableStatus>();
        Ui.WireButton(this, "Thêm", (_, _) => Add());
        Ui.WireButton(this, "Cập nhật", (_, _) => UpdateItem());
        Ui.WireButton(this, "Xóa", (_, _) => Delete());
        Ui.WireButton(this, "Làm mới", (_, _) => ClearEditor());
        Ui.WireButton(this, "Tìm", (_, _) => LoadData());
        Ui.WireButton(this, "Tất cả", (_, _) => { _search.Clear(); LoadData(); });
        _grid.CellClick += (_, _) => SelectRow();
        _grid.CellFormatting += GridCellFormatting;
        Load += (_, _) => LoadData();
    }

    private void LoadData()
    {
        using var db = new CafeDbContext();
        string keyword = _search.Text.Trim();
        _grid.DataSource = db.CafeTables.AsNoTracking()
            .Where(x => keyword == "" || x.Name.Contains(keyword))
            .OrderBy(x => x.Name)
            .Select(x => new
            {
                x.Id,
                TenBan = x.Name,
                TrangThai = x.Status == TableStatus.Empty ? "Trống" : x.Status == TableStatus.Serving ? "Đang phục vụ" : "Đã đặt"
            }).ToList();
        if (_grid.Columns["Id"] is not null) _grid.Columns["Id"].Visible = false;
    }

    private void GridCellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (_grid.Columns[e.ColumnIndex].Name != "TrangThai" || e.Value is not string status) return;
        e.CellStyle.BackColor = status switch
        {
            "Trống" => Color.Honeydew,
            "Đang phục vụ" => Color.MistyRose,
            _ => Color.LemonChiffon
        };
    }

    private bool ValidateInput()
    {
        if (_name.Text.Trim().Length < 2)
        {
            Ui.Error("Tên bàn phải có ít nhất 2 ký tự.");
            return false;
        }
        return true;
    }

    private void Add()
    {
        if (!ValidateInput()) return;
        using var db = new CafeDbContext();
        if (db.CafeTables.Any(x => x.Name == _name.Text.Trim()))
        {
            Ui.Error("Tên bàn đã tồn tại.");
            return;
        }
        db.CafeTables.Add(new CafeTable { Name = _name.Text.Trim(), Status = (TableStatus)_status.SelectedItem! });
        db.SaveChanges();
        ClearEditor();
        LoadData();
    }

    private void UpdateItem()
    {
        if (_selectedId is null || !ValidateInput()) return;
        using var db = new CafeDbContext();
        var item = db.CafeTables.Find(_selectedId.Value);
        if (item is null) return;
        if (item.Status == TableStatus.Serving && (TableStatus)_status.SelectedItem! != TableStatus.Serving)
        {
            bool hasOpenInvoice = db.Invoices.Any(x => x.TableId == item.Id && x.Status == InvoiceStatus.Open);
            if (hasOpenInvoice)
            {
                Ui.Error("Bàn đang có hóa đơn mở. Hãy thanh toán hoặc chuyển bàn trước.");
                return;
            }
        }
        item.Name = _name.Text.Trim();
        item.Status = (TableStatus)_status.SelectedItem!;
        db.SaveChanges();
        LoadData();
    }

    private void Delete()
    {
        if (_selectedId is null || !Ui.Confirm("Xóa bàn đang chọn?")) return;
        using var db = new CafeDbContext();
        var item = db.CafeTables.Include(x => x.Invoices).SingleOrDefault(x => x.Id == _selectedId.Value);
        if (item is null) return;
        if (item.Status == TableStatus.Serving || item.Invoices.Count > 0)
        {
            Ui.Error("Không thể xóa bàn đang phục vụ hoặc đã có lịch sử hóa đơn.");
            return;
        }
        db.CafeTables.Remove(item);
        db.SaveChanges();
        ClearEditor();
        LoadData();
    }

    private void SelectRow()
    {
        if (_grid.CurrentRow?.Cells["Id"].Value is not int id) return;
        using var db = new CafeDbContext();
        var item = db.CafeTables.Find(id);
        if (item is null) return;
        _selectedId = id;
        _name.Text = item.Name;
        _status.SelectedItem = item.Status;
    }

    private void ClearEditor()
    {
        _selectedId = null;
        _name.Clear();
        _status.SelectedItem = TableStatus.Empty;
        _grid.ClearSelection();
    }
}
