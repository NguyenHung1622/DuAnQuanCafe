#nullable disable

namespace CafeManager.WinForms.Forms;

partial class ChangePasswordForm
{
    private System.ComponentModel.IContainer components = null;
    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        _panel = new TableLayoutPanel();
        _oldLabel = new Label();
        _oldPassword = new TextBox();
        _newLabel = new Label();
        _newPassword = new TextBox();
        _confirmLabel = new Label();
        _confirmPassword = new TextBox();
        _buttons = new FlowLayoutPanel();
        _saveButton = new Button();
        _closeButton = new Button();
        _panel.SuspendLayout();
        _buttons.SuspendLayout();
        SuspendLayout();

        _panel.ColumnCount = 2;
        _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _panel.Controls.Add(_oldLabel, 0, 0);
        _panel.Controls.Add(_oldPassword, 1, 0);
        _panel.Controls.Add(_newLabel, 0, 1);
        _panel.Controls.Add(_newPassword, 1, 1);
        _panel.Controls.Add(_confirmLabel, 0, 2);
        _panel.Controls.Add(_confirmPassword, 1, 2);
        _panel.Dock = DockStyle.Top;
        _panel.Height = 190;
        _panel.Padding = new Padding(25);
        _panel.RowCount = 3;
        _oldLabel.Dock = DockStyle.Fill;
        _oldLabel.Text = "Mật khẩu cũ";
        _oldLabel.TextAlign = ContentAlignment.MiddleLeft;
        _oldPassword.Dock = DockStyle.Fill;
        _oldPassword.UseSystemPasswordChar = true;
        _newLabel.Dock = DockStyle.Fill;
        _newLabel.Text = "Mật khẩu mới";
        _newLabel.TextAlign = ContentAlignment.MiddleLeft;
        _newPassword.Dock = DockStyle.Fill;
        _newPassword.UseSystemPasswordChar = true;
        _confirmLabel.Dock = DockStyle.Fill;
        _confirmLabel.Text = "Nhập lại";
        _confirmLabel.TextAlign = ContentAlignment.MiddleLeft;
        _confirmPassword.Dock = DockStyle.Fill;
        _confirmPassword.UseSystemPasswordChar = true;

        _buttons.Controls.AddRange(new Control[] { _saveButton, _closeButton });
        _buttons.Dock = DockStyle.Top;
        _buttons.Height = 55;
        _buttons.Padding = new Padding(85, 5, 0, 0);
        _saveButton.Height = 36;
        _saveButton.Text = "Lưu mật khẩu";
        _saveButton.Width = 140;
        _closeButton.Height = 36;
        _closeButton.Text = "Đóng";
        _closeButton.Width = 100;

        AcceptButton = _saveButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(470, 280);
        Controls.Add(_buttons);
        Controls.Add(_panel);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ChangePasswordForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Đổi mật khẩu";
        _panel.ResumeLayout(false);
        _panel.PerformLayout();
        _buttons.ResumeLayout(false);
        ResumeLayout(false);
    }

    private TableLayoutPanel _panel;
    private Label _oldLabel;
    private TextBox _oldPassword;
    private Label _newLabel;
    private TextBox _newPassword;
    private Label _confirmLabel;
    private TextBox _confirmPassword;
    private FlowLayoutPanel _buttons;
    private Button _saveButton;
    private Button _closeButton;
}
