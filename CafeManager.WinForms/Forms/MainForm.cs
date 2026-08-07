using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Services;

namespace CafeManager.WinForms.Forms;

public sealed partial class MainForm : Form
{
    private Form? _child;

    public MainForm()
    {
        InitializeComponent();
        _userLabel.Text = $"{AppSession.CurrentAccount?.Employee?.FullName}\n({AppSession.CurrentAccount?.Role})";
        Ui.WireButton(this, "Bán hàng", (_, _) => Open(new SalesForm()));
        Ui.WireButton(this, "Bàn", (_, _) => Open(new TableManagementForm()));
        Ui.WireButton(this, "Danh mục", (_, _) => Open(new CategoryManagementForm()));
        Ui.WireButton(this, "Đồ uống", (_, _) => Open(new ProductManagementForm()));
        Ui.WireButton(this, "Khách hàng", (_, _) => Open(new CustomerManagementForm()));
        Ui.WireButton(this, "Thống kê", (_, _) => Open(new ReportsForm()));
        Ui.WireButton(this, "Nhân viên", (_, _) => Open(new EmployeeManagementForm()));
        Ui.WireButton(this, "Tài khoản", (_, _) => Open(new AccountManagementForm()));
        Ui.WireButton(this, "Nhật ký", (_, _) => Open(new LoginLogForm()));
        Ui.WireButton(this, "Đổi mật khẩu", (_, _) => new ChangePasswordForm().ShowDialog(this));
        Ui.WireButton(this, "Đăng xuất", (_, _) => Close());

        foreach (string adminText in new[] { "Nhân viên", "Tài khoản", "Nhật ký" })
        {
            Button? adminButton = Ui.FindButton(this, adminText);
            if (adminButton is not null)
                adminButton.Visible = AppSession.IsAdmin;
        }

        Shown += (_, _) => Open(new SalesForm());
        FormClosed += (_, _) => WriteLogout();
    }

    private Button MenuButton(string text, Action action)
    {
        var button = Ui.Button(text, (_, _) => action(), 180);
        button.Height = 42;
        return button;
    }

    private void Open(Form child)
    {
        _child?.Close();
        _child?.Dispose();
        _child = child;
        child.TopLevel = false;
        child.FormBorderStyle = FormBorderStyle.None;
        child.Dock = DockStyle.Fill;
        _content.Controls.Clear();
        _content.Controls.Add(child);
        child.Show();
    }

    private static void WriteLogout()
    {
        if (AppSession.CurrentLoginLogId is not int id) return;
        try
        {
            using var db = new CafeDbContext();
            var log = db.LoginLogs.Find(id);
            if (log is not null)
            {
                log.LogoutAt = DateTime.Now;
                db.SaveChanges();
            }
        }
        catch
        {
            // Không chặn đăng xuất khi không ghi được nhật ký.
        }
    }
}
