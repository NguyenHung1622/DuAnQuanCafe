using CafeManager.WinForms.Models;

namespace CafeManager.WinForms.Services;

public static class AppSession
{
    public static Account? CurrentAccount { get; set; }
    public static int? CurrentLoginLogId { get; set; }

    public static bool IsAdmin => CurrentAccount?.Role == AccountRole.Admin;
    public static int EmployeeId => CurrentAccount?.EmployeeId
        ?? throw new InvalidOperationException("Tài khoản chưa liên kết nhân viên.");

    public static void Clear()
    {
        CurrentAccount = null;
        CurrentLoginLogId = null;
    }
}
