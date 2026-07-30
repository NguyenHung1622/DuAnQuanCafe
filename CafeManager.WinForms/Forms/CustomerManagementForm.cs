using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Forms;

public sealed class CustomerManagementForm : Form
{
    private readonly DataGridView _grid = Ui.Grid();
    private readonly DataGridView _historyGrid = Ui.Grid();
    private readonly TextBox _search = Ui.TextBox(200);
    private readonly TextBox _fullName = Ui.TextBox();
    private readonly TextBox _phone = Ui.TextBox();
    private readonly TextBox _address = Ui.TextBox();
    private readonly NumericUpDown _points = new() { Width = 220, Maximum = 1_000_000, Font = Ui.NormalFont };
    private int? _selectedId;

    public CustomerManagementForm()
    {
        Text = "Quản lý khách hàng";
        var split = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal, SplitterDistance = 390 };
        split.Panel1.Controls.Add(_grid);
        split.Panel2.Controls.Add(_historyGrid);
        split.Panel2.Controls.Add(new Label { Text = "Lịch sử mua hàng", Dock = DockStyle.Top, Height = 35, Font = new Font("Segoe UI Semibold", 12F), TextAlign = ContentAlignment.MiddleLeft });

        var editor = new TableLayoutPanel { Dock = DockStyle.Right, Width = 390, Padding = new Padding(15), ColumnCount = 2, RowCount = 6 };
        editor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
        editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        AddRow(editor, 0, "Họ tên", _fullName);
        AddRow(editor, 1, "Điện thoại", _phone);
        AddRow(editor, 2, "Địa chỉ", _address);
        AddRow(editor, 3, "Điểm", _points);
        var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, WrapContents = true };
        buttons.Controls.AddRange([
            Ui.Button("Thêm", (_, _) => Add()),
            Ui.Button("Cập nhật", (_, _) => UpdateItem()),
            Ui.Button("Xóa", (_, _) => Delete()),
            Ui.Button("Cộng điểm", (_, _) => AddPoints()),
            Ui.Button("Làm mới", (_, _) => ClearEditor())
        ]);
        editor.Controls.Add(buttons, 0, 4);
        editor.SetColumnSpan(buttons, 2);

        Controls.Add(split);
        Controls.Add(editor);
        Controls.Add(Ui.Row(Ui.Label("Tìm khách", 90), _search,
            Ui.Button("Tìm", (_, _) => LoadData()),
            Ui.Button("Tất cả", (_, _) => { _search.Clear(); LoadData(); })));
        _grid.CellClick += (_, _) => SelectRow();
        Load += (_, _) => LoadData();
    }

    private static void AddRow(TableLayoutPanel panel, int row, string label, Control control)
    {
        panel.Controls.Add(Ui.Label(label, 115), 0, row);
        panel.Controls.Add(control, 1, row);
    }

    private void LoadData()
    {
        using var db = new CafeDbContext();
        string keyword = _search.Text.Trim();
        _grid.DataSource = db.Customers.AsNoTracking()
            .Where(x => keyword == "" || x.FullName.Contains(keyword) || x.Phone.Contains(keyword))
            .OrderBy(x => x.FullName)
            .Select(x => new { x.Id, HoTen = x.FullName, DienThoai = x.Phone, DiaChi = x.Address, Diem = x.Points, SoLanMua = x.Invoices.Count(i => i.Status == InvoiceStatus.Paid) }).ToList();
        if (_grid.Columns["Id"] is not null) _grid.Columns["Id"].Visible = false;
    }

    private bool ValidateInput()
    {
        if (_fullName.Text.Trim().Length < 2)
        {
            Ui.Error("Họ tên phải có ít nhất 2 ký tự.");
            return false;
        }
        string phone = _phone.Text.Trim();
        if (phone.Length > 0 && (phone.Length < 9 || !phone.All(char.IsDigit)))
        {
            Ui.Error("Số điện thoại không hợp lệ.");
            return false;
        }
        return true;
    }

    private void Add()
    {
        if (!ValidateInput()) return;
        using var db = new CafeDbContext();
        string phone = _phone.Text.Trim();
        if (phone.Length > 0 && db.Customers.Any(x => x.Phone == phone))
        {
            Ui.Error("Số điện thoại đã tồn tại.");
            return;
        }
        db.Customers.Add(new Customer { FullName = _fullName.Text.Trim(), Phone = phone, Address = _address.Text.Trim(), Points = (int)_points.Value });
        db.SaveChanges();
        ClearEditor();
        LoadData();
    }

    private void UpdateItem()
    {
        if (_selectedId is null || !ValidateInput()) return;
        using var db = new CafeDbContext();
        string phone = _phone.Text.Trim();
        if (phone.Length > 0 && db.Customers.Any(x => x.Phone == phone && x.Id != _selectedId.Value))
        {
            Ui.Error("Số điện thoại đã tồn tại.");
            return;
        }
        var item = db.Customers.Find(_selectedId.Value);
        if (item is null) return;
        item.FullName = _fullName.Text.Trim();
        item.Phone = phone;
        item.Address = _address.Text.Trim();
        item.Points = (int)_points.Value;
        db.SaveChanges();
        LoadData();
    }

    private void Delete()
    {
        if (_selectedId is null || !Ui.Confirm("Xóa khách hàng đang chọn?")) return;
        using var db = new CafeDbContext();
        var item = db.Customers.Include(x => x.Invoices).SingleOrDefault(x => x.Id == _selectedId.Value);
        if (item is null) return;
        if (item.Invoices.Count > 0)
        {
            Ui.Error("Không thể xóa khách hàng đã có lịch sử mua hàng.");
            return;
        }
        db.Customers.Remove(item);
        db.SaveChanges();
        ClearEditor();
        LoadData();
    }

    private void AddPoints()
    {
        if (_selectedId is null) return;
        string? value = PromptDialog.Show(this, "Tích điểm", "Nhập số điểm cần cộng", "10");
        if (!int.TryParse(value, out int points) || points <= 0)
        {
            Ui.Error("Số điểm không hợp lệ.");
            return;
        }
        using var db = new CafeDbContext();
        var item = db.Customers.Find(_selectedId.Value);
        if (item is null) return;
        item.Points += points;
        db.SaveChanges();
        _points.Value = item.Points;
        LoadData();
    }

    private void SelectRow()
    {
        if (_grid.CurrentRow?.Cells["Id"].Value is not int id) return;
        using var db = new CafeDbContext();
        var item = db.Customers.Find(id);
        if (item is null) return;
        _selectedId = id;
        _fullName.Text = item.FullName;
        _phone.Text = item.Phone;
        _address.Text = item.Address;
        _points.Value = item.Points;
        LoadHistory(id);
    }

    private void LoadHistory(int customerId)
    {
        using var db = new CafeDbContext();
        _historyGrid.DataSource = db.Invoices.AsNoTracking().Include(x => x.Table)
            .Where(x => x.CustomerId == customerId && x.Status == InvoiceStatus.Paid)
            .OrderByDescending(x => x.PaidAt)
            .Select(x => new { MaHoaDon = x.Id, NgayMua = x.PaidAt, Ban = x.Table != null ? x.Table.Name : "", TongTien = x.Total }).ToList();
        if (_historyGrid.Columns["TongTien"] is not null) _historyGrid.Columns["TongTien"].DefaultCellStyle.Format = "N0";
    }

    private void ClearEditor()
    {
        _selectedId = null;
        _fullName.Clear();
        _phone.Clear();
        _address.Clear();
        _points.Value = 0;
        _historyGrid.DataSource = null;
        _grid.ClearSelection();
    }
}
