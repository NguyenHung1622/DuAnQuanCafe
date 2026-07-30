using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Forms;

public sealed class TableManagementForm : Form
{
    private readonly DataGridView _grid = Ui.Grid();
    private readonly TextBox _search = Ui.TextBox(200);
    private readonly TextBox _name = Ui.TextBox();
    private readonly ComboBox _status = Ui.ComboBox();
    private int? _selectedId;

    public TableManagementForm()
    {
        Text = "Quản lý bàn";
        _status.DataSource = Enum.GetValues<TableStatus>();

        var editor = new TableLayoutPanel { Dock = DockStyle.Right, Width = 390, Padding = new Padding(15), ColumnCount = 2, RowCount = 4 };
        editor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
        editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        editor.Controls.Add(Ui.Label("Tên bàn", 115), 0, 0);
        editor.Controls.Add(_name, 1, 0);
        editor.Controls.Add(Ui.Label("Trạng thái", 115), 0, 1);
        editor.Controls.Add(_status, 1, 1);
        var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, WrapContents = true };
        buttons.Controls.AddRange([
            Ui.Button("Thêm", (_, _) => Add()),
            Ui.Button("Cập nhật", (_, _) => UpdateItem()),
            Ui.Button("Xóa", (_, _) => Delete()),
            Ui.Button("Làm mới", (_, _) => ClearEditor())
        ]);
        editor.Controls.Add(buttons, 0, 2);
        editor.SetColumnSpan(buttons, 2);

        Controls.Add(_grid);
        Controls.Add(editor);
        Controls.Add(Ui.Row(Ui.Label("Tìm bàn", 80), _search,
            Ui.Button("Tìm", (_, _) => LoadData()),
            Ui.Button("Tất cả", (_, _) => { _search.Clear(); LoadData(); })));
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
