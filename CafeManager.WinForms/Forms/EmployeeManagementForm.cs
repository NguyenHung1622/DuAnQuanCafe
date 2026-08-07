using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Forms;

public sealed partial class EmployeeManagementForm : Form
{
    private int? _selectedId;

    public EmployeeManagementForm()
    {
        InitializeComponent();
        _gender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
        _gender.SelectedIndex = 0;
        Ui.WireButton(this, "Thêm", (_, _) => Add());
        Ui.WireButton(this, "Cập nhật", (_, _) => UpdateItem());
        Ui.WireButton(this, "Xóa", (_, _) => Delete());
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
        _grid.DataSource = db.Employees.AsNoTracking()
            .Where(x => keyword == "" || x.FullName.Contains(keyword) || x.Phone.Contains(keyword) || x.Position.Contains(keyword))
            .OrderBy(x => x.FullName)
            .Select(x => new
            {
                x.Id,
                HoTen = x.FullName,
                GioiTinh = x.Gender,
                NgaySinh = x.BirthDate,
                DienThoai = x.Phone,
                DiaChi = x.Address,
                ChucVu = x.Position,
                NgayVaoLam = x.HireDate
            }).ToList();
        if (_grid.Columns["Id"] is not null) _grid.Columns["Id"].Visible = false;
    }

    private bool ValidateInput()
    {
        if (_fullName.Text.Trim().Length < 2)
        {
            Ui.Error("Họ tên phải có ít nhất 2 ký tự.");
            return false;
        }
        if (_phone.Text.Trim().Length > 0 && (_phone.Text.Trim().Length < 9 || !_phone.Text.Trim().All(char.IsDigit)))
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
        db.Employees.Add(new CafeManager.WinForms.Models.Employee
        {
            FullName = _fullName.Text.Trim(),
            Gender = _gender.Text,
            BirthDate = _birthDate.Value.Date,
            Phone = _phone.Text.Trim(),
            Address = _address.Text.Trim(),
            Position = _position.Text.Trim(),
            HireDate = _hireDate.Value.Date
        });
        db.SaveChanges();
        ClearEditor();
        LoadData();
    }

    private void UpdateItem()
    {
        if (_selectedId is null || !ValidateInput()) return;
        using var db = new CafeDbContext();
        var item = db.Employees.Find(_selectedId.Value);
        if (item is null) return;
        item.FullName = _fullName.Text.Trim();
        item.Gender = _gender.Text;
        item.BirthDate = _birthDate.Value.Date;
        item.Phone = _phone.Text.Trim();
        item.Address = _address.Text.Trim();
        item.Position = _position.Text.Trim();
        item.HireDate = _hireDate.Value.Date;
        db.SaveChanges();
        LoadData();
    }

    private void Delete()
    {
        if (_selectedId is null || !Ui.Confirm("Xóa nhân viên đang chọn?")) return;
        using var db = new CafeDbContext();
        var item = db.Employees.Include(x => x.Invoices).Include(x => x.Account).SingleOrDefault(x => x.Id == _selectedId.Value);
        if (item is null) return;
        if (item.Invoices.Count > 0 || item.Account is not null)
        {
            Ui.Error("Không thể xóa nhân viên đã có tài khoản hoặc hóa đơn. Hãy khóa tài khoản thay vì xóa.");
            return;
        }
        db.Employees.Remove(item);
        db.SaveChanges();
        ClearEditor();
        LoadData();
    }

    private void SelectRow()
    {
        if (_grid.CurrentRow?.Cells["Id"].Value is not int id) return;
        using var db = new CafeDbContext();
        var item = db.Employees.Find(id);
        if (item is null) return;
        _selectedId = id;
        _fullName.Text = item.FullName;
        _gender.SelectedItem = item.Gender;
        _birthDate.Value = item.BirthDate;
        _phone.Text = item.Phone;
        _address.Text = item.Address;
        _position.Text = item.Position;
        _hireDate.Value = item.HireDate;
    }

    private void ClearEditor()
    {
        _selectedId = null;
        _fullName.Clear();
        _gender.SelectedIndex = 0;
        _birthDate.Value = DateTime.Today.AddYears(-20);
        _phone.Clear();
        _address.Clear();
        _position.Text = "Nhân viên";
        _hireDate.Value = DateTime.Today;
        _grid.ClearSelection();
    }
}
