namespace CafeManager.WinForms.Helpers;

public sealed class PromptDialog : Form
{
    private readonly TextBox _textBox;
    public string Value => _textBox.Text.Trim();

    public PromptDialog(string title, string label, string defaultValue = "", bool password = false)
    {
        Text = title;
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(420, 150);
        Font = Ui.NormalFont;

        _textBox = Ui.TextBox(370, password);
        _textBox.Text = defaultValue;

        var buttons = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom,
            Height = 55,
            FlowDirection = FlowDirection.RightToLeft,
            Padding = new Padding(10)
        };
        var ok = Ui.Button("Đồng ý", (_, _) => { DialogResult = DialogResult.OK; Close(); });
        var cancel = Ui.Button("Hủy", (_, _) => { DialogResult = DialogResult.Cancel; Close(); });
        buttons.Controls.AddRange([ok, cancel]);

        Controls.Add(buttons);
        Controls.Add(Ui.Row(Ui.Label(label, 390), _textBox));
        AcceptButton = ok;
        CancelButton = cancel;
    }

    public static string? Show(IWin32Window owner, string title, string label, string defaultValue = "", bool password = false)
    {
        using var dialog = new PromptDialog(title, label, defaultValue, password);
        return dialog.ShowDialog(owner) == DialogResult.OK ? dialog.Value : null;
    }
}
