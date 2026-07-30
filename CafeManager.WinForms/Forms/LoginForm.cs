using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Models;
using CafeManager.WinForms.Security;
using CafeManager.WinForms.Services;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Forms;

public sealed class LoginForm : Form
{
    private readonly TextBox _txtUsername = Ui.TextBox(270);
    private readonly TextBox _txtPassword = Ui.TextBox(270, true);

    public LoginForm()
    {
        Text = "Đăng nhập - Cafe Manager";
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        ClientSize = new Size(480, 330);
        Font = Ui.NormalFont;

        var title = new Label
        {
            Text = "CAFE MANAGER",
            Font = new Font("Segoe UI Semibold", 25F),
            Dock = DockStyle.Top,
            Height = 80,
            TextAlign = ContentAlignment.MiddleCenter
        };

        var formPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 145,
            Padding = new Padding(35, 15, 35, 5),
            ColumnCount = 2,
            RowCount = 2
        };
        formPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));
        formPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        formPanel.Controls.Add(Ui.Label("Tài khoản", 105), 0, 0);
        formPanel.Controls.Add(_txtUsername, 1, 0);
        formPanel.Controls.Add(Ui.Label("Mật khẩu", 105), 0, 1);
        formPanel.Controls.Add(_txtPassword, 1, 1);

        var btnLogin = Ui.Button("Đăng nhập", (_, _) => Login(), 130);
        var btnForgot = Ui.Button("Quên mật khẩu", (_, _) =>
            Ui.Info("Hãy liên hệ tài khoản Admin để đặt lại mật khẩu trong mục Quản lý tài khoản."), 150);
        var buttons = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 60,
            FlowDirection = FlowDirection.LeftToRight,
            Padding = new Padding(95, 5, 0, 0)
        };
        buttons.Controls.AddRange([btnLogin, btnForgot]);

        var note = new Label
        {
            Text = "Tài khoản mẫu: admin / 123456   |   nhanvien / 123456",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.TopCenter,
            ForeColor = Color.DimGray
        };

        Controls.Add(note);
        Controls.Add(buttons);
        Controls.Add(formPanel);
        Controls.Add(title);

        AcceptButton = btnLogin;
        Shown += (_, _) => _txtUsername.Focus();
    }

    private void Login()
    {
        string username = _txtUsername.Text.Trim();
        string password = _txtPassword.Text;

        if (username.Length == 0 || password.Length == 0)
        {
            Ui.Error("Vui lòng nhập tài khoản và mật khẩu.");
            return;
        }

        using var db = new CafeDbContext();
        Account? account = db.Accounts
            .Include(x => x.Employee)
            .SingleOrDefault(x => x.Username == username);

        bool success = account is not null && account.IsActive && PasswordHasher.Verify(password, account.PasswordHash);
        var log = new LoginLog
        {
            AccountId = account?.Id,
            LoginAt = DateTime.Now,
            Success = success,
            Note = success ? "Đăng nhập thành công" : account is { IsActive: false } ? "Tài khoản bị khóa" : "Sai tài khoản hoặc mật khẩu"
        };
        db.LoginLogs.Add(log);
        db.SaveChanges();

        if (!success)
        {
            Ui.Error(account is { IsActive: false }
                ? "Tài khoản đã bị khóa. Vui lòng liên hệ Admin."
                : "Sai tài khoản hoặc mật khẩu.");
            _txtPassword.Clear();
            _txtPassword.Focus();
            return;
        }

        AppSession.CurrentAccount = account;
        AppSession.CurrentLoginLogId = log.Id;

        Hide();
        using var main = new MainForm();
        main.ShowDialog();
        AppSession.Clear();
        _txtPassword.Clear();
        Show();
        Activate();
    }
}
