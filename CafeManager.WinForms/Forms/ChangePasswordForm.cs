using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Security;
using CafeManager.WinForms.Services;

namespace CafeManager.WinForms.Forms;

public sealed partial class ChangePasswordForm : Form
{
    public ChangePasswordForm()
    {
        InitializeComponent();
        Ui.WireButton(this, "Lưu mật khẩu", (_, _) => SavePassword());
        Ui.WireButton(this, "Đóng", (_, _) => Close());
    }

    private void SavePassword()
    {
        if (_newPassword.Text.Length < 6)
        {
            Ui.Error("Mật khẩu mới phải có ít nhất 6 ký tự.");
            return;
        }
        if (_newPassword.Text != _confirmPassword.Text)
        {
            Ui.Error("Mật khẩu nhập lại không khớp.");
            return;
        }

        using var db = new CafeDbContext();
        var account = db.Accounts.Find(AppSession.CurrentAccount!.Id);
        if (account is null || !PasswordHasher.Verify(_oldPassword.Text, account.PasswordHash))
        {
            Ui.Error("Mật khẩu cũ không đúng.");
            return;
        }

        account.PasswordHash = PasswordHasher.Hash(_newPassword.Text);
        db.SaveChanges();
        Ui.Info("Đổi mật khẩu thành công.");
        Close();
    }
}
