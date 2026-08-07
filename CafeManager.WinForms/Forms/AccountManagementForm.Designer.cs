#nullable disable

namespace CafeManager.WinForms.Forms;

partial class AccountManagementForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        _grid = new DataGridView();
        _toolbar = new FlowLayoutPanel();
        _lblSearch = new Label();
        _search = new TextBox();
        _btnSearch = new Button();
        _btnAll = new Button();
        _editor = new TableLayoutPanel();
        _lblUsername = new Label();
        _username = new TextBox();
        _lblPassword = new Label();
        _password = new TextBox();
        _lblRole = new Label();
        _role = new ComboBox();
        _lblEmployee = new Label();
        _employee = new ComboBox();
        _active = new CheckBox();
        _buttonPanel = new FlowLayoutPanel();
        _btnAdd = new Button();
        _btnUpdate = new Button();
        _btnDelete = new Button();
        _btnToggle = new Button();
        _btnReset = new Button();
        _btnClear = new Button();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        _toolbar.SuspendLayout();
        _editor.SuspendLayout();
        _buttonPanel.SuspendLayout();
        SuspendLayout();
        // 
        // _grid
        // 
        _grid.AllowUserToAddRows = false;
        _grid.AllowUserToDeleteRows = false;
        _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _grid.BackgroundColor = SystemColors.Window;
        _grid.ColumnHeadersHeight = 29;
        _grid.Dock = DockStyle.Fill;
        _grid.Location = new Point(0, 52);
        _grid.MultiSelect = false;
        _grid.Name = "_grid";
        _grid.ReadOnly = true;
        _grid.RowHeadersVisible = false;
        _grid.RowHeadersWidth = 51;
        _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _grid.Size = new Size(710, 648);
        _grid.TabIndex = 0;
        // 
        // _toolbar
        // 
        _toolbar.Controls.Add(_lblSearch);
        _toolbar.Controls.Add(_search);
        _toolbar.Controls.Add(_btnSearch);
        _toolbar.Controls.Add(_btnAll);
        _toolbar.Dock = DockStyle.Top;
        _toolbar.Location = new Point(0, 0);
        _toolbar.Name = "_toolbar";
        _toolbar.Padding = new Padding(5);
        _toolbar.Size = new Size(1100, 52);
        _toolbar.TabIndex = 2;
        // 
        // _lblSearch
        // 
        _lblSearch.Location = new Point(8, 5);
        _lblSearch.Name = "_lblSearch";
        _lblSearch.Size = new Size(115, 32);
        _lblSearch.TabIndex = 0;
        _lblSearch.Text = "Tìm tài khoản";
        _lblSearch.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _search
        // 
        _search.Location = new Point(129, 8);
        _search.Name = "_search";
        _search.Size = new Size(210, 30);
        _search.TabIndex = 1;
        // 
        // _btnSearch
        // 
        _btnSearch.AutoSize = true;
        _btnSearch.Location = new Point(345, 8);
        _btnSearch.Name = "_btnSearch";
        _btnSearch.Size = new Size(75, 33);
        _btnSearch.TabIndex = 2;
        _btnSearch.Text = "Tìm";
        _btnSearch.UseVisualStyleBackColor = true;
        // 
        // _btnAll
        // 
        _btnAll.AutoSize = true;
        _btnAll.Location = new Point(426, 8);
        _btnAll.Name = "_btnAll";
        _btnAll.Size = new Size(75, 33);
        _btnAll.TabIndex = 3;
        _btnAll.Text = "Tất cả";
        _btnAll.UseVisualStyleBackColor = true;
        // 
        // _editor
        // 
        _editor.ColumnCount = 2;
        _editor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        _editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _editor.Controls.Add(_lblUsername, 0, 0);
        _editor.Controls.Add(_username, 1, 0);
        _editor.Controls.Add(_lblPassword, 0, 1);
        _editor.Controls.Add(_password, 1, 1);
        _editor.Controls.Add(_lblRole, 0, 2);
        _editor.Controls.Add(_role, 1, 2);
        _editor.Controls.Add(_lblEmployee, 0, 3);
        _editor.Controls.Add(_employee, 1, 3);
        _editor.Controls.Add(_active, 1, 4);
        _editor.Controls.Add(_buttonPanel, 0, 5);
        _editor.Dock = DockStyle.Right;
        _editor.Location = new Point(710, 52);
        _editor.Name = "_editor";
        _editor.Padding = new Padding(12);
        _editor.RowCount = 7;
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _editor.Size = new Size(390, 648);
        _editor.TabIndex = 1;
        // 
        // _lblUsername
        // 
        _lblUsername.Dock = DockStyle.Fill;
        _lblUsername.Location = new Point(15, 12);
        _lblUsername.Name = "_lblUsername";
        _lblUsername.Size = new Size(114, 20);
        _lblUsername.TabIndex = 0;
        _lblUsername.Text = "Tài khoản";
        _lblUsername.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _username
        // 
        _username.Dock = DockStyle.Fill;
        _username.Location = new Point(135, 15);
        _username.Name = "_username";
        _username.Size = new Size(240, 30);
        _username.TabIndex = 1;
        // 
        // _lblPassword
        // 
        _lblPassword.Dock = DockStyle.Fill;
        _lblPassword.Location = new Point(15, 32);
        _lblPassword.Name = "_lblPassword";
        _lblPassword.Size = new Size(114, 20);
        _lblPassword.TabIndex = 2;
        _lblPassword.Text = "Mật khẩu";
        _lblPassword.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _password
        // 
        _password.Dock = DockStyle.Fill;
        _password.Location = new Point(135, 35);
        _password.Name = "_password";
        _password.Size = new Size(240, 30);
        _password.TabIndex = 3;
        _password.UseSystemPasswordChar = true;
        // 
        // _lblRole
        // 
        _lblRole.Dock = DockStyle.Fill;
        _lblRole.Location = new Point(15, 52);
        _lblRole.Name = "_lblRole";
        _lblRole.Size = new Size(114, 20);
        _lblRole.TabIndex = 4;
        _lblRole.Text = "Vai trò";
        _lblRole.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _role
        // 
        _role.Dock = DockStyle.Fill;
        _role.DropDownStyle = ComboBoxStyle.DropDownList;
        _role.Location = new Point(135, 55);
        _role.Name = "_role";
        _role.Size = new Size(240, 31);
        _role.TabIndex = 5;
        // 
        // _lblEmployee
        // 
        _lblEmployee.Dock = DockStyle.Fill;
        _lblEmployee.Location = new Point(15, 72);
        _lblEmployee.Name = "_lblEmployee";
        _lblEmployee.Size = new Size(114, 20);
        _lblEmployee.TabIndex = 6;
        _lblEmployee.Text = "Nhân viên";
        _lblEmployee.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _employee
        // 
        _employee.Dock = DockStyle.Fill;
        _employee.DropDownStyle = ComboBoxStyle.DropDownList;
        _employee.Location = new Point(135, 75);
        _employee.Name = "_employee";
        _employee.Size = new Size(240, 31);
        _employee.TabIndex = 7;
        // 
        // _active
        // 
        _active.AutoSize = true;
        _active.Checked = true;
        _active.CheckState = CheckState.Checked;
        _active.Location = new Point(135, 95);
        _active.Name = "_active";
        _active.Size = new Size(158, 14);
        _active.TabIndex = 8;
        _active.Text = "Đang hoạt động";
        // 
        // _buttonPanel
        // 
        _buttonPanel.AutoSize = true;
        _editor.SetColumnSpan(_buttonPanel, 2);
        _buttonPanel.Controls.Add(_btnAdd);
        _buttonPanel.Controls.Add(_btnUpdate);
        _buttonPanel.Controls.Add(_btnDelete);
        _buttonPanel.Controls.Add(_btnToggle);
        _buttonPanel.Controls.Add(_btnReset);
        _buttonPanel.Controls.Add(_btnClear);
        _buttonPanel.Dock = DockStyle.Fill;
        _buttonPanel.Location = new Point(15, 115);
        _buttonPanel.Name = "_buttonPanel";
        _buttonPanel.Size = new Size(360, 14);
        _buttonPanel.TabIndex = 9;
        // 
        // _btnAdd
        // 
        _btnAdd.AutoSize = true;
        _btnAdd.Location = new Point(3, 3);
        _btnAdd.Name = "_btnAdd";
        _btnAdd.Size = new Size(75, 33);
        _btnAdd.TabIndex = 0;
        _btnAdd.Text = "Thêm";
        _btnAdd.UseVisualStyleBackColor = true;
        // 
        // _btnUpdate
        // 
        _btnUpdate.AutoSize = true;
        _btnUpdate.Location = new Point(84, 3);
        _btnUpdate.Name = "_btnUpdate";
        _btnUpdate.Size = new Size(90, 33);
        _btnUpdate.TabIndex = 1;
        _btnUpdate.Text = "Cập nhật";
        _btnUpdate.UseVisualStyleBackColor = true;
        // 
        // _btnDelete
        // 
        _btnDelete.AutoSize = true;
        _btnDelete.Location = new Point(180, 3);
        _btnDelete.Name = "_btnDelete";
        _btnDelete.Size = new Size(75, 33);
        _btnDelete.TabIndex = 2;
        _btnDelete.Text = "Xóa";
        _btnDelete.UseVisualStyleBackColor = true;
        // 
        // _btnToggle
        // 
        _btnToggle.AutoSize = true;
        _btnToggle.Location = new Point(261, 3);
        _btnToggle.Name = "_btnToggle";
        _btnToggle.Size = new Size(91, 33);
        _btnToggle.TabIndex = 3;
        _btnToggle.Text = "Khóa/Mở";
        _btnToggle.UseVisualStyleBackColor = true;
        // 
        // _btnReset
        // 
        _btnReset.AutoSize = true;
        _btnReset.Location = new Point(3, 42);
        _btnReset.Name = "_btnReset";
        _btnReset.Size = new Size(91, 33);
        _btnReset.TabIndex = 4;
        _btnReset.Text = "Reset MK";
        _btnReset.UseVisualStyleBackColor = true;
        // 
        // _btnClear
        // 
        _btnClear.AutoSize = true;
        _btnClear.Location = new Point(100, 42);
        _btnClear.Name = "_btnClear";
        _btnClear.Size = new Size(86, 33);
        _btnClear.TabIndex = 5;
        _btnClear.Text = "Làm mới";
        _btnClear.UseVisualStyleBackColor = true;
        // 
        // AccountManagementForm
        // 
        AutoScaleDimensions = new SizeF(9F, 23F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1100, 700);
        Controls.Add(_grid);
        Controls.Add(_editor);
        Controls.Add(_toolbar);
        Font = new Font("Segoe UI", 10F);
        Name = "AccountManagementForm";
        Text = "Quản lý tài khoản";
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        _toolbar.ResumeLayout(false);
        _toolbar.PerformLayout();
        _editor.ResumeLayout(false);
        _editor.PerformLayout();
        _buttonPanel.ResumeLayout(false);
        _buttonPanel.PerformLayout();
        ResumeLayout(false);
    }

    private DataGridView _grid;
    private FlowLayoutPanel _toolbar;
    private Label _lblSearch;
    private TextBox _search;
    private Button _btnSearch;
    private Button _btnAll;
    private TableLayoutPanel _editor;
    private Label _lblUsername;
    private TextBox _username;
    private Label _lblPassword;
    private TextBox _password;
    private Label _lblRole;
    private ComboBox _role;
    private Label _lblEmployee;
    private ComboBox _employee;
    private CheckBox _active;
    private FlowLayoutPanel _buttonPanel;
    private Button _btnAdd;
    private Button _btnUpdate;
    private Button _btnDelete;
    private Button _btnToggle;
    private Button _btnReset;
    private Button _btnClear;
}
