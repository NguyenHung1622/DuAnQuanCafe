using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Models;
using CafeManager.WinForms.Security;
using CafeManager.WinForms.Services;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Forms;

public sealed partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
        Ui.WireButton(this, "Đăng nhập", (_, _) => Login());
        Ui.WireButton(this, "Quên mật khẩu", (_, _) =>
            Ui.Info("Hãy liên hệ tài khoản Admin để đặt lại mật khẩu trong mục Quản lý tài khoản."));
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
