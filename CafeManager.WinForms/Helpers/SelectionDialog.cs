namespace CafeManager.WinForms.Helpers;

public sealed class SelectionItem<T>
{
    public required string Text { get; init; }
    public required T Value { get; init; }
    public override string ToString() => Text;
}

public sealed class SelectionDialog<T> : Form
{
    private readonly ComboBox _combo;
    public T SelectedValue
    {
        get
        {
            if (_combo.SelectedItem is SelectionItem<T> item) return item.Value;
            throw new InvalidOperationException("Chưa có mục nào được chọn.");
        }
    }

    public SelectionDialog(string title, string label, IEnumerable<SelectionItem<T>> items)
    {
        Text = title;
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(440, 155);

        _combo = Ui.ComboBox(390);
        foreach (var item in items) _combo.Items.Add(item);
        if (_combo.Items.Count > 0) _combo.SelectedIndex = 0;

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
        Controls.Add(Ui.Row(Ui.Label(label, 390), _combo));
        AcceptButton = ok;
        CancelButton = cancel;
    }
}
