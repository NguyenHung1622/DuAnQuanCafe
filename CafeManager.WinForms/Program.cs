using CafeManager.WinForms.Data;
using CafeManager.WinForms.Forms;

namespace CafeManager.WinForms;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        try
        {
            DatabaseInitializer.Initialize();
            Application.Run(new LoginForm());
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Không thể khởi động ứng dụng.\n\n{ex.Message}",
                "Cafe Manager",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
