#nullable disable

namespace CafeManager.WinForms.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        _headerLabel = new Label();
        _sidebar = new FlowLayoutPanel();
        _userLabel = new Label();
        _salesButton = new Button();
        _tablesButton = new Button();
        _categoriesButton = new Button();
        _productsButton = new Button();
        _customersButton = new Button();
        _reportsButton = new Button();
        _employeesButton = new Button();
        _accountsButton = new Button();
        _logsButton = new Button();
        _changePasswordButton = new Button();
        _logoutButton = new Button();
        _content = new Panel();
        _sidebar.SuspendLayout();
        SuspendLayout();
        // 
        // _headerLabel
        // 
        _headerLabel.Dock = DockStyle.Top;
        _headerLabel.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point);
        _headerLabel.Location = new Point(210, 0);
        _headerLabel.Name = "_headerLabel";
        _headerLabel.Size = new Size(890, 65);
        _headerLabel.TabIndex = 1;
        _headerLabel.Text = "HỆ THỐNG QUẢN LÝ QUÁN CÀ PHÊ";
        _headerLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _sidebar
        // 
        _sidebar.AutoScroll = true;
        _sidebar.BackColor = Color.WhiteSmoke;
        _sidebar.Controls.Add(_userLabel);
        _sidebar.Controls.Add(_salesButton);
        _sidebar.Controls.Add(_tablesButton);
        _sidebar.Controls.Add(_categoriesButton);
        _sidebar.Controls.Add(_productsButton);
        _sidebar.Controls.Add(_customersButton);
        _sidebar.Controls.Add(_reportsButton);
        _sidebar.Controls.Add(_employeesButton);
        _sidebar.Controls.Add(_accountsButton);
        _sidebar.Controls.Add(_logsButton);
        _sidebar.Controls.Add(_changePasswordButton);
        _sidebar.Controls.Add(_logoutButton);
        _sidebar.Dock = DockStyle.Left;
        _sidebar.FlowDirection = FlowDirection.TopDown;
        _sidebar.Location = new Point(0, 0);
        _sidebar.Name = "_sidebar";
        _sidebar.Padding = new Padding(10);
        _sidebar.Size = new Size(210, 700);
        _sidebar.TabIndex = 0;
        _sidebar.WrapContents = false;
        // 
        // _userLabel
        // 
        _userLabel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
        _userLabel.Location = new Point(13, 10);
        _userLabel.Name = "_userLabel";
        _userLabel.Size = new Size(180, 85);
        _userLabel.TabIndex = 0;
        _userLabel.Text = "Người dùng\r\n(Vai trò)";
        _userLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _salesButton
        // 
        _salesButton.FlatStyle = FlatStyle.Flat;
        _salesButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _salesButton.Location = new Point(15, 105);
        _salesButton.Margin = new Padding(5);
        _salesButton.Name = "_salesButton";
        _salesButton.Size = new Size(180, 40);
        _salesButton.TabIndex = 1;
        _salesButton.Text = "Bán hàng";
        _salesButton.UseVisualStyleBackColor = true;
        // 
        // _tablesButton
        // 
        _tablesButton.FlatStyle = FlatStyle.Flat;
        _tablesButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _tablesButton.Location = new Point(15, 155);
        _tablesButton.Margin = new Padding(5);
        _tablesButton.Name = "_tablesButton";
        _tablesButton.Size = new Size(180, 40);
        _tablesButton.TabIndex = 2;
        _tablesButton.Text = "Bàn";
        _tablesButton.UseVisualStyleBackColor = true;
        // 
        // _categoriesButton
        // 
        _categoriesButton.FlatStyle = FlatStyle.Flat;
        _categoriesButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _categoriesButton.Location = new Point(15, 205);
        _categoriesButton.Margin = new Padding(5);
        _categoriesButton.Name = "_categoriesButton";
        _categoriesButton.Size = new Size(180, 40);
        _categoriesButton.TabIndex = 3;
        _categoriesButton.Text = "Danh mục";
        _categoriesButton.UseVisualStyleBackColor = true;
        // 
        // _productsButton
        // 
        _productsButton.FlatStyle = FlatStyle.Flat;
        _productsButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _productsButton.Location = new Point(15, 255);
        _productsButton.Margin = new Padding(5);
        _productsButton.Name = "_productsButton";
        _productsButton.Size = new Size(180, 40);
        _productsButton.TabIndex = 4;
        _productsButton.Text = "Đồ uống";
        _productsButton.UseVisualStyleBackColor = true;
        // 
        // _customersButton
        // 
        _customersButton.FlatStyle = FlatStyle.Flat;
        _customersButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _customersButton.Location = new Point(15, 305);
        _customersButton.Margin = new Padding(5);
        _customersButton.Name = "_customersButton";
        _customersButton.Size = new Size(180, 40);
        _customersButton.TabIndex = 5;
        _customersButton.Text = "Khách hàng";
        _customersButton.UseVisualStyleBackColor = true;
        // 
        // _reportsButton
        // 
        _reportsButton.FlatStyle = FlatStyle.Flat;
        _reportsButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _reportsButton.Location = new Point(15, 355);
        _reportsButton.Margin = new Padding(5);
        _reportsButton.Name = "_reportsButton";
        _reportsButton.Size = new Size(180, 40);
        _reportsButton.TabIndex = 6;
        _reportsButton.Text = "Thống kê";
        _reportsButton.UseVisualStyleBackColor = true;
        // 
        // _employeesButton
        // 
        _employeesButton.FlatStyle = FlatStyle.Flat;
        _employeesButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _employeesButton.Location = new Point(15, 405);
        _employeesButton.Margin = new Padding(5);
        _employeesButton.Name = "_employeesButton";
        _employeesButton.Size = new Size(180, 40);
        _employeesButton.TabIndex = 7;
        _employeesButton.Text = "Nhân viên";
        _employeesButton.UseVisualStyleBackColor = true;
        // 
        // _accountsButton
        // 
        _accountsButton.FlatStyle = FlatStyle.Flat;
        _accountsButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _accountsButton.Location = new Point(15, 455);
        _accountsButton.Margin = new Padding(5);
        _accountsButton.Name = "_accountsButton";
        _accountsButton.Size = new Size(180, 40);
        _accountsButton.TabIndex = 8;
        _accountsButton.Text = "Tài khoản";
        _accountsButton.UseVisualStyleBackColor = true;
        // 
        // _logsButton
        // 
        _logsButton.FlatStyle = FlatStyle.Flat;
        _logsButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _logsButton.Location = new Point(15, 505);
        _logsButton.Margin = new Padding(5);
        _logsButton.Name = "_logsButton";
        _logsButton.Size = new Size(180, 40);
        _logsButton.TabIndex = 9;
        _logsButton.Text = "Nhật ký";
        _logsButton.UseVisualStyleBackColor = true;
        // 
        // _changePasswordButton
        // 
        _changePasswordButton.FlatStyle = FlatStyle.Flat;
        _changePasswordButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _changePasswordButton.Location = new Point(15, 555);
        _changePasswordButton.Margin = new Padding(5);
        _changePasswordButton.Name = "_changePasswordButton";
        _changePasswordButton.Size = new Size(180, 40);
        _changePasswordButton.TabIndex = 10;
        _changePasswordButton.Text = "Đổi mật khẩu";
        _changePasswordButton.UseVisualStyleBackColor = true;
        // 
        // _logoutButton
        // 
        _logoutButton.FlatStyle = FlatStyle.Flat;
        _logoutButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _logoutButton.Location = new Point(15, 605);
        _logoutButton.Margin = new Padding(5);
        _logoutButton.Name = "_logoutButton";
        _logoutButton.Size = new Size(180, 40);
        _logoutButton.TabIndex = 11;
        _logoutButton.Text = "Đăng xuất";
        _logoutButton.UseVisualStyleBackColor = true;
        // 
        // _content
        // 
        _content.BackColor = Color.White;
        _content.Dock = DockStyle.Fill;
        _content.Location = new Point(210, 65);
        _content.Name = "_content";
        _content.Size = new Size(890, 635);
        _content.TabIndex = 2;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1100, 700);
        Controls.Add(_content);
        Controls.Add(_headerLabel);
        Controls.Add(_sidebar);
        MinimumSize = new Size(1100, 700);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Cafe Manager - Quản lý quán café";
        WindowState = FormWindowState.Maximized;
        _sidebar.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Label _headerLabel;
    private FlowLayoutPanel _sidebar;
    private Label _userLabel;
    private Button _salesButton;
    private Button _tablesButton;
    private Button _categoriesButton;
    private Button _productsButton;
    private Button _customersButton;
    private Button _reportsButton;
    private Button _employeesButton;
    private Button _accountsButton;
    private Button _logsButton;
    private Button _changePasswordButton;
    private Button _logoutButton;
    private Panel _content;
}
