using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Forms;

public sealed partial class CustomerManagementForm : Form
{
    private int? _selectedId;

    public CustomerManagementForm()
    {
        InitializeComponent();
        Ui.WireButton(this, "Thêm", (_, _) => Add());
        Ui.WireButton(this, "Cập nhật", (_, _) => UpdateItem());
        Ui.WireButton(this, "Xóa", (_, _) => Delete());
        Ui.WireButton(this, "Cộng điểm", (_, _) => AddPoints());
        Ui.WireButton(this, "Làm mới", (_, _) => ClearEditor());
        Ui.WireButton(this, "Tìm", (_, _) => LoadData());
        Ui.WireButton(this, "Tất cả", (_, _) => { _search.Clear(); LoadData(); });
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
