#nullable disable

namespace CafeManager.WinForms.Forms;

partial class TableManagementForm
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
        _allButton = new Button();
        _editor = new TableLayoutPanel();
        _nameLabel = new Label();
        _name = new TextBox();
        _statusLabel = new Label();
        _status = new ComboBox();
        _buttons = new FlowLayoutPanel();
        _addButton = new Button();
        _updateButton = new Button();
        _deleteButton = new Button();
        _clearButton = new Button();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        _toolbar.SuspendLayout();
        _editor.SuspendLayout();
        _buttons.SuspendLayout();
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

        _toolbar.Controls.AddRange(new Control[] { _searchLabel, _search, _searchButton, _allButton });
        _toolbar.Dock = DockStyle.Top;
        _toolbar.Height = 52;
        _toolbar.Padding = new Padding(5);
        _searchLabel.Size = new Size(80, 32);
        _searchLabel.Text = "Tìm bàn";
        _searchLabel.TextAlign = ContentAlignment.MiddleLeft;
        _search.Size = new Size(200, 31);
        _searchButton.AutoSize = true;
        _searchButton.Text = "Tìm";
        _allButton.AutoSize = true;
        _allButton.Text = "Tất cả";

        _editor.ColumnCount = 2;
        _editor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        _editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _editor.Controls.Add(_nameLabel, 0, 0);
        _editor.Controls.Add(_name, 1, 0);
        _editor.Controls.Add(_statusLabel, 0, 1);
        _editor.Controls.Add(_status, 1, 1);
        _editor.Controls.Add(_buttons, 0, 2);
        _editor.Dock = DockStyle.Right;
        _editor.Padding = new Padding(15);
        _editor.RowCount = 4;
        _editor.SetColumnSpan(_buttons, 2);
        _editor.Width = 390;
        _nameLabel.Dock = DockStyle.Fill;
        _nameLabel.Text = "Tên bàn";
        _name.Dock = DockStyle.Fill;
        _statusLabel.Dock = DockStyle.Fill;
        _statusLabel.Text = "Trạng thái";
        _status.Dock = DockStyle.Fill;
        _status.DropDownStyle = ComboBoxStyle.DropDownList;

        _buttons.AutoSize = true;
        _buttons.Controls.AddRange(new Control[] { _addButton, _updateButton, _deleteButton, _clearButton });
        _buttons.Dock = DockStyle.Fill;
        _addButton.AutoSize = true;
        _addButton.Text = "Thêm";
        _updateButton.AutoSize = true;
        _updateButton.Text = "Cập nhật";
        _deleteButton.AutoSize = true;
        _deleteButton.Text = "Xóa";
        _clearButton.AutoSize = true;
        _clearButton.Text = "Làm mới";

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 650);
        Controls.Add(_grid);
        Controls.Add(_editor);
        Controls.Add(_toolbar);
        Font = new Font("Segoe UI", 10F);
        Name = "TableManagementForm";
        Text = "Quản lý bàn";
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        _toolbar.ResumeLayout(false);
        _toolbar.PerformLayout();
        _editor.ResumeLayout(false);
        _editor.PerformLayout();
        _buttons.ResumeLayout(false);
        ResumeLayout(false);
    }

    private DataGridView _grid;
    private FlowLayoutPanel _toolbar;
    private Label _searchLabel;
    private TextBox _search;
    private Button _searchButton;
    private Button _allButton;
    private TableLayoutPanel _editor;
    private Label _nameLabel;
    private TextBox _name;
    private Label _statusLabel;
    private ComboBox _status;
    private FlowLayoutPanel _buttons;
    private Button _addButton;
    private Button _updateButton;
    private Button _deleteButton;
    private Button _clearButton;
}
