#nullable disable

namespace CafeManager.WinForms.Forms;

partial class LoginLogForm
{
    private System.ComponentModel.IContainer components = null;
    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        _grid = new DataGridView();
        _toolbar = new FlowLayoutPanel();
        _searchLabel = new Label();
        _search = new TextBox();
        _searchButton = new Button();
        _refreshButton = new Button();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        _toolbar.SuspendLayout();
        SuspendLayout();

        _grid.AllowUserToAddRows = false;
        _grid.AllowUserToDeleteRows = false;
        _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _grid.BackgroundColor = SystemColors.Window;
        _grid.Dock = DockStyle.Fill;
        _grid.Name = "_grid";
        _grid.ReadOnly = true;
        _grid.RowHeadersVisible = false;
        _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _toolbar.Controls.AddRange(new Control[] { _searchLabel, _search, _searchButton, _refreshButton });
        _toolbar.Dock = DockStyle.Top;
        _toolbar.Height = 52;
        _toolbar.Padding = new Padding(5);
        _searchLabel.Size = new Size(110, 32);
        _searchLabel.Text = "Tìm tài khoản";
        _searchLabel.TextAlign = ContentAlignment.MiddleLeft;
        _search.Size = new Size(220, 31);
        _searchButton.AutoSize = true;
        _searchButton.Text = "Tìm";
        _refreshButton.AutoSize = true;
        _refreshButton.Text = "Làm mới";

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1100, 700);
        Controls.Add(_grid);
        Controls.Add(_toolbar);
        Font = new Font("Segoe UI", 10F);
        Name = "LoginLogForm";
        Text = "Nhật ký đăng nhập";
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        _toolbar.ResumeLayout(false);
        _toolbar.PerformLayout();
        ResumeLayout(false);
    }

    private DataGridView _grid;
    private FlowLayoutPanel _toolbar;
    private Label _searchLabel;
    private TextBox _search;
    private Button _searchButton;
    private Button _refreshButton;
}
