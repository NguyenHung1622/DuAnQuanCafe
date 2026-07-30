using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Models;
using CafeManager.WinForms.Security;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Forms;

public sealed class AccountManagementForm : Form
{
    private readonly DataGridView _grid = Ui.Grid();
    private readonly TextBox _search = Ui.TextBox(210);
    private readonly TextBox _username = Ui.TextBox();
    private readonly TextBox _password = Ui.TextBox(220, true);
    private readonly ComboBox _role = Ui.ComboBox();
    private readonly ComboBox _employee = Ui.ComboBox();
    private readonly CheckBox _active = new() { Text = "Đang hoạt động", Checked = true, AutoSize = true, Margin = new Padding(8) };
    private int? _selectedId;

    public AccountManagementForm()
    {
        Text = "Quản lý tài khoản";
        _role.DataSource = Enum.GetValues<AccountRole>();

        var editor = new TableLayoutPanel
        {
            Dock = DockStyle.Right,
            Width = 390,
            Padding = new Padding(12),
            ColumnCount = 2,
            RowCount = 7
        };
        editor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
        editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        AddRow(editor, 0, "Tài khoản", _username);
        AddRow(editor, 1, "Mật khẩu", _password);
        AddRow(editor, 2, "Vai trò", _role);
        AddRow(editor, 3, "Nhân viên", _employee);
        editor.Controls.Add(_active, 1, 4);

        var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, WrapContents = true };
        buttons.Controls.AddRange([
            Ui.Button("Thêm", (_, _) => Add()),
            Ui.Button("Cập nhật", (_, _) => UpdateItem()),
            Ui.Button("Xóa", (_, _) => Delete()),
            Ui.Button("Khóa/Mở", (_, _) => ToggleActive()),
            Ui.Button("Reset MK", (_, _) => ResetPassword()),
            Ui.Button("Làm mới", (_, _) => ClearEditor())
        ]);
        editor.Controls.Add(buttons, 0, 5);
        editor.SetColumnSpan(buttons, 2);

        Controls.Add(_grid);
        Controls.Add(editor);
        Controls.Add(Ui.Row(Ui.Label("Tìm tài khoản", 115), _search,
            Ui.Button("Tìm", (_, _) => LoadData()),
            Ui.Button("Tất cả", (_, _) => { _search.Clear(); LoadData(); })));

        _grid.CellClick += (_, _) => SelectRow();
        Load += (_, _) => { LoadEmployees(); LoadData(); };
    }

    private static void AddRow(TableLayoutPanel panel, int row, string label, Control control)
    {
        panel.Controls.Add(Ui.Label(label, 115), 0, row);
        panel.Controls.Add(control, 1, row);
    }

    private void LoadEmployees()
    {
        using var db = new CafeDbContext();
        var items = db.Employees.AsNoTracking().OrderBy(x => x.FullName)
            .Select(x => new { x.Id, x.FullName }).ToList();
        _employee.DisplayMember = "FullName";
        _employee.ValueMember = "Id";
        _employee.DataSource = items;
    }

    private void LoadData()
    {
        using var db = new CafeDbContext();
        string keyword = _search.Text.Trim();
        _grid.DataSource = db.Accounts.AsNoTracking().Include(x => x.Employee)
            .Where(x => keyword == "" || x.Username.Contains(keyword) || (x.Employee != null && x.Employee.FullName.Contains(keyword)))
            .OrderBy(x => x.Username)
            .Select(x => new
            {
                x.Id,
                TaiKhoan = x.Username,
                VaiTro = x.Role,
                NhanVien = x.Employee != null ? x.Employee.FullName : "Chưa liên kết",
                TrangThai = x.IsActive ? "Hoạt động" : "Đã khóa",
                x.EmployeeId
            }).ToList();
        if (_grid.Columns["Id"] is not null) _grid.Columns["Id"].Visible = false;
        if (_grid.Columns["EmployeeId"] is not null) _grid.Columns["EmployeeId"].Visible = false;
    }

    private void Add()
    {
        string username = _username.Text.Trim();
        if (username.Length < 3 || _password.Text.Length < 6)
        {
            Ui.Error("Tài khoản tối thiểu 3 ký tự và mật khẩu tối thiểu 6 ký tự.");
            return;
        }
        if (_employee.SelectedValue is not int employeeId) return;

        using var db = new CafeDbContext();
        if (db.Accounts.Any(x => x.Username == username))
        {
            Ui.Error("Tên tài khoản đã tồn tại.");
            return;
        }
        if (db.Accounts.Any(x => x.EmployeeId == employeeId))
        {
            Ui.Error("Nhân viên này đã có tài khoản.");
            return;
        }

        db.Accounts.Add(new Account
        {
            Username = username,
            PasswordHash = PasswordHasher.Hash(_password.Text),
            Role = (AccountRole)_role.SelectedItem!,
            EmployeeId = employeeId,
            IsActive = _active.Checked
        });
        db.SaveChanges();
        ClearEditor();
        LoadData();
    }

    private void UpdateItem()
    {
        if (_selectedId is null || _employee.SelectedValue is not int employeeId) return;
        string username = _username.Text.Trim();
        if (username.Length < 3)
        {
            Ui.Error("Tên tài khoản tối thiểu 3 ký tự.");
            return;
        }

        using var db = new CafeDbContext();
        if (db.Accounts.Any(x => x.Username == username && x.Id != _selectedId.Value))
        {
            Ui.Error("Tên tài khoản đã tồn tại.");
            return;
        }
        if (db.Accounts.Any(x => x.EmployeeId == employeeId && x.Id != _selectedId.Value))
        {
            Ui.Error("Nhân viên này đã có tài khoản.");
            return;
        }
        var account = db.Accounts.Find(_selectedId.Value);
        if (account is null) return;
        account.Username = username;
        account.Role = (AccountRole)_role.SelectedItem!;
        account.EmployeeId = employeeId;
        account.IsActive = _active.Checked;
        if (_password.Text.Length >= 6) account.PasswordHash = PasswordHasher.Hash(_password.Text);
        db.SaveChanges();
        LoadData();
    }

    private void Delete()
    {
        if (_selectedId is null || !Ui.Confirm("Xóa tài khoản đang chọn?")) return;
        using var db = new CafeDbContext();
        var account = db.Accounts.Include(x => x.LoginLogs).SingleOrDefault(x => x.Id == _selectedId.Value);
        if (account is null) return;
        if (account.Username == "admin")
        {
            Ui.Error("Không được xóa tài khoản admin mặc định.");
            return;
        }
        if (account.LoginLogs.Count > 0)
        {
            account.IsActive = false;
            db.SaveChanges();
            Ui.Info("Tài khoản đã có lịch sử đăng nhập nên được khóa thay vì xóa.");
        }
        else
        {
            db.Accounts.Remove(account);
            db.SaveChanges();
        }
        ClearEditor();
        LoadData();
    }

    private void ToggleActive()
    {
        if (_selectedId is null) return;
        using var db = new CafeDbContext();
        var account = db.Accounts.Find(_selectedId.Value);
        if (account is null) return;
        if (account.Username == "admin" && account.IsActive)
        {
            Ui.Error("Không được khóa tài khoản admin mặc định.");
            return;
        }
        account.IsActive = !account.IsActive;
        db.SaveChanges();
        _active.Checked = account.IsActive;
        LoadData();
    }

    private void ResetPassword()
    {
        if (_selectedId is null) return;
        string? newPassword = PromptDialog.Show(this, "Reset mật khẩu", "Nhập mật khẩu mới (ít nhất 6 ký tự)", "123456", true);
        if (newPassword is null) return;
        if (newPassword.Length < 6)
        {
            Ui.Error("Mật khẩu phải có ít nhất 6 ký tự.");
            return;
        }
        using var db = new CafeDbContext();
        var account = db.Accounts.Find(_selectedId.Value);
        if (account is null) return;
        account.PasswordHash = PasswordHasher.Hash(newPassword);
        db.SaveChanges();
        Ui.Info("Đã đặt lại mật khẩu.");
    }

    private void SelectRow()
    {
        if (_grid.CurrentRow?.Cells["Id"].Value is not int id) return;
        using var db = new CafeDbContext();
        var account = db.Accounts.Find(id);
        if (account is null) return;
        _selectedId = id;
        _username.Text = account.Username;
        _password.Clear();
        _role.SelectedItem = account.Role;
        _employee.SelectedValue = account.EmployeeId;
        _active.Checked = account.IsActive;
    }

    private void ClearEditor()
    {
        _selectedId = null;
        _username.Clear();
        _password.Clear();
        _role.SelectedItem = AccountRole.Employee;
        if (_employee.Items.Count > 0) _employee.SelectedIndex = 0;
        _active.Checked = true;
        _grid.ClearSelection();
    }
}
