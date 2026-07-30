using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Security;
using CafeManager.WinForms.Services;

namespace CafeManager.WinForms.Forms;

public sealed class ChangePasswordForm : Form
{
    private readonly TextBox _oldPassword = Ui.TextBox(260, true);
    private readonly TextBox _newPassword = Ui.TextBox(260, true);
    private readonly TextBox _confirmPassword = Ui.TextBox(260, true);

    public ChangePasswordForm()
    {
        Text = "Đổi mật khẩu";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(470, 280);

        var panel = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 190,
            Padding = new Padding(25),
            ColumnCount = 2,
            RowCount = 3
        };
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        panel.Controls.Add(Ui.Label("Mật khẩu cũ", 145), 0, 0);
        panel.Controls.Add(_oldPassword, 1, 0);
        panel.Controls.Add(Ui.Label("Mật khẩu mới", 145), 0, 1);
        panel.Controls.Add(_newPassword, 1, 1);
        panel.Controls.Add(Ui.Label("Nhập lại", 145), 0, 2);
        panel.Controls.Add(_confirmPassword, 1, 2);

        var save = Ui.Button("Lưu mật khẩu", (_, _) => SavePassword(), 140);
        var close = Ui.Button("Đóng", (_, _) => Close());
        Controls.Add(Ui.Row(save, close));
        Controls.Add(panel);
        AcceptButton = save;
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
