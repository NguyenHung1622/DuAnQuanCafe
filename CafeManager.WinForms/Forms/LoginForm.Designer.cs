#nullable disable

namespace CafeManager.WinForms.Forms;

partial class LoginForm
{
    private System.ComponentModel.IContainer components = null;
    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        _title = new Label();
        _formPanel = new TableLayoutPanel();
        _usernameLabel = new Label();
        _txtUsername = new TextBox();
        _passwordLabel = new Label();
        _txtPassword = new TextBox();
        _buttons = new FlowLayoutPanel();
        _loginButton = new Button();
        _forgotButton = new Button();
        _note = new Label();
        _formPanel.SuspendLayout();
        _buttons.SuspendLayout();
        SuspendLayout();

        _title.Dock = DockStyle.Top;
        _title.Font = new Font("Segoe UI Semibold", 25F);
        _title.Height = 80;
        _title.Name = "_title";
        _title.Text = "CAFE MANAGER";
        _title.TextAlign = ContentAlignment.MiddleCenter;

        _formPanel.ColumnCount = 2;
        _formPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
        _formPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _formPanel.Controls.Add(_usernameLabel, 0, 0);
        _formPanel.Controls.Add(_txtUsername, 1, 0);
        _formPanel.Controls.Add(_passwordLabel, 0, 1);
        _formPanel.Controls.Add(_txtPassword, 1, 1);
        _formPanel.Dock = DockStyle.Top;
        _formPanel.Height = 145;
        _formPanel.Padding = new Padding(35, 15, 35, 5);
        _formPanel.RowCount = 2;
        _usernameLabel.Dock = DockStyle.Fill;
        _usernameLabel.Text = "Tài khoản";
        _usernameLabel.TextAlign = ContentAlignment.MiddleLeft;
        _txtUsername.Dock = DockStyle.Fill;
        _txtUsername.Name = "_txtUsername";
        _passwordLabel.Dock = DockStyle.Fill;
        _passwordLabel.Text = "Mật khẩu";
        _passwordLabel.TextAlign = ContentAlignment.MiddleLeft;
        _txtPassword.Dock = DockStyle.Fill;
        _txtPassword.Name = "_txtPassword";
        _txtPassword.UseSystemPasswordChar = true;

        _buttons.Controls.AddRange(new Control[] { _loginButton, _forgotButton });
        _buttons.Dock = DockStyle.Top;
        _buttons.Height = 60;
        _buttons.Padding = new Padding(95, 5, 0, 0);
        _loginButton.Height = 36;
        _loginButton.Text = "Đăng nhập";
        _loginButton.Width = 130;
        _forgotButton.Height = 36;
        _forgotButton.Text = "Quên mật khẩu";
        _forgotButton.Width = 150;

        _note.Dock = DockStyle.Fill;
        _note.ForeColor = Color.DimGray;
        _note.Text = "Tài khoản mẫu: admin / 123456   |   nhanvien / 123456";
        _note.TextAlign = ContentAlignment.TopCenter;

        AcceptButton = _loginButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(480, 330);
        Controls.Add(_note);
        Controls.Add(_buttons);
        Controls.Add(_formPanel);
        Controls.Add(_title);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Đăng nhập - Cafe Manager";
        _formPanel.ResumeLayout(false);
        _formPanel.PerformLayout();
        _buttons.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Label _title;
    private TableLayoutPanel _formPanel;
    private Label _usernameLabel;
    private TextBox _txtUsername;
    private Label _passwordLabel;
    private TextBox _txtPassword;
    private FlowLayoutPanel _buttons;
    private Button _loginButton;
    private Button _forgotButton;
    private Label _note;
}
