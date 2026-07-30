namespace CafeManager.WinForms.Helpers;

public static class Ui
{
    public static readonly Font NormalFont = new("Segoe UI", 10F);
    public static readonly Font HeaderFont = new("Segoe UI Semibold", 17F);

    public static Button Button(string text, EventHandler? click = null, int width = 110)
    {
        var button = new Button
        {
            Text = text,
            Width = width,
            Height = 36,
            Margin = new Padding(5),
            Font = NormalFont,
            FlatStyle = FlatStyle.Flat,
            UseVisualStyleBackColor = true
        };
        if (click is not null) button.Click += click;
        return button;
    }

    public static TextBox TextBox(int width = 220, bool password = false) => new()
    {
        Width = width,
        Font = NormalFont,
        UseSystemPasswordChar = password,
        Margin = new Padding(5)
    };

    public static ComboBox ComboBox(int width = 220) => new()
    {
        Width = width,
        Font = NormalFont,
        DropDownStyle = ComboBoxStyle.DropDownList,
        Margin = new Padding(5)
    };

    public static Label Label(string text, int width = 120) => new()
    {
        Text = text,
        Width = width,
        Height = 30,
        TextAlign = ContentAlignment.MiddleLeft,
        Font = NormalFont,
        Margin = new Padding(5)
    };

    public static DataGridView Grid() => new()
    {
        Dock = DockStyle.Fill,
        ReadOnly = true,
        AllowUserToAddRows = false,
        AllowUserToDeleteRows = false,
        MultiSelect = false,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        RowHeadersVisible = false,
        BackgroundColor = SystemColors.Window,
        BorderStyle = BorderStyle.Fixed3D,
        Font = NormalFont
    };

    public static FlowLayoutPanel Row(params Control[] controls)
    {
        var panel = new FlowLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            WrapContents = true,
            Padding = new Padding(5)
        };
        panel.Controls.AddRange(controls);
        return panel;
    }

    public static bool Confirm(string message) => MessageBox.Show(
        message,
        "Xác nhận",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question) == DialogResult.Yes;

    public static void Info(string message) => MessageBox.Show(
        message,
        "Thông báo",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);

    public static void Error(string message) => MessageBox.Show(
        message,
        "Lỗi",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error);

    public static string Money(decimal amount) => amount.ToString("N0") + " đ";
}
