using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Services;

namespace CafeManager.WinForms.Forms;

public sealed class MainForm : Form
{
    private readonly Panel _content = new() { Dock = DockStyle.Fill };
    private Form? _child;

    public MainForm()
    {
        Text = "Cafe Manager - Quản lý quán café";
        WindowState = FormWindowState.Maximized;
        MinimumSize = new Size(1100, 700);

        var sidebar = new FlowLayoutPanel
        {
            Dock = DockStyle.Left,
            Width = 210,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = true,
            Padding = new Padding(10)
        };

        var lblUser = new Label
        {
            Width = 180,
            Height = 85,
            Font = new Font("Segoe UI Semibold", 11F),
            TextAlign = ContentAlignment.MiddleCenter,
            Text = $"{AppSession.CurrentAccount?.Employee?.FullName}\n({AppSession.CurrentAccount?.Role})"
        };
        sidebar.Controls.Add(lblUser);
        sidebar.Controls.Add(MenuButton("Bán hàng", () => Open(new SalesForm())));
        sidebar.Controls.Add(MenuButton("Bàn", () => Open(new TableManagementForm())));
        sidebar.Controls.Add(MenuButton("Danh mục", () => Open(new CategoryManagementForm())));
        sidebar.Controls.Add(MenuButton("Đồ uống", () => Open(new ProductManagementForm())));
        sidebar.Controls.Add(MenuButton("Khách hàng", () => Open(new CustomerManagementForm())));
        sidebar.Controls.Add(MenuButton("Thống kê", () => Open(new ReportsForm())));

        if (AppSession.IsAdmin)
        {
            sidebar.Controls.Add(MenuButton("Nhân viên", () => Open(new EmployeeManagementForm())));
            sidebar.Controls.Add(MenuButton("Tài khoản", () => Open(new AccountManagementForm())));
            sidebar.Controls.Add(MenuButton("Nhật ký", () => Open(new LoginLogForm())));
        }

        sidebar.Controls.Add(MenuButton("Đổi mật khẩu", () => new ChangePasswordForm().ShowDialog(this)));
        sidebar.Controls.Add(MenuButton("Đăng xuất", Close));

        var header = new Label
        {
            Dock = DockStyle.Top,
            Height = 65,
            Text = "HỆ THỐNG QUẢN LÝ QUÁN CÀ PHÊ",
            Font = new Font("Segoe UI Semibold", 20F),
            TextAlign = ContentAlignment.MiddleCenter
        };

        Controls.Add(_content);
        Controls.Add(sidebar);
        Controls.Add(header);

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
