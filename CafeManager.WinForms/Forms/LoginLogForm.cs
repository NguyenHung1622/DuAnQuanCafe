using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Forms;

public sealed partial class LoginLogForm : Form
{
    public LoginLogForm()
    {
        InitializeComponent();
        Ui.WireButton(this, "Tìm", (_, _) => LoadData());
        Ui.WireButton(this, "Làm mới", (_, _) => { _search.Clear(); LoadData(); });
        Load += (_, _) => LoadData();
    }

    private void LoadData()
    {
        using var db = new CafeDbContext();
        string keyword = _search.Text.Trim();
        var data = db.LoginLogs.AsNoTracking()
            .Include(x => x.Account)
            .Where(x => keyword == "" || (x.Account != null && x.Account.Username.Contains(keyword)))
            .OrderByDescending(x => x.LoginAt)
            .Take(1000)
            .Select(x => new
            {
                x.Id,
                TaiKhoan = x.Account != null ? x.Account.Username : "Không xác định",
                DangNhap = x.LoginAt,
                DangXuat = x.LogoutAt,
                ThanhCong = x.Success ? "Có" : "Không",
                GhiChu = x.Note
            }).ToList();
        _grid.DataSource = data;
    }
}
