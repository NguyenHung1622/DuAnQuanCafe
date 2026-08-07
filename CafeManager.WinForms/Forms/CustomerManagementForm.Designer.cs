#nullable disable

namespace CafeManager.WinForms.Forms;

partial class CustomerManagementForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        _split = new SplitContainer();
        _grid = new DataGridView();
        _historyGrid = new DataGridView();
        _historyTitle = new Label();
        _toolbar = new FlowLayoutPanel();
        _lblSearch = new Label();
        _search = new TextBox();
        _btnSearch = new Button();
        _btnAll = new Button();
        _editor = new TableLayoutPanel();
        _lblFullName = new Label();
        _fullName = new TextBox();
        _lblPhone = new Label();
        _phone = new TextBox();
        _lblAddress = new Label();
        _address = new TextBox();
        _lblPoints = new Label();
        _points = new NumericUpDown();
        _buttonPanel = new FlowLayoutPanel();
        _btnAdd = new Button();
        _btnUpdate = new Button();
        _btnDelete = new Button();
        _btnAddPoints = new Button();
        _btnClear = new Button();
        ((System.ComponentModel.ISupportInitialize)_split).BeginInit();
        _split.Panel1.SuspendLayout();
        _split.Panel2.SuspendLayout();
        _split.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_historyGrid).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_points).BeginInit();
        _toolbar.SuspendLayout();
        _editor.SuspendLayout();
        _buttonPanel.SuspendLayout();
        SuspendLayout();

        _split.Dock = DockStyle.Fill;
        _split.Name = "_split";
        _split.Orientation = Orientation.Horizontal;
        _split.SplitterDistance = 390;
        _split.Panel1.Controls.Add(_grid);
        _split.Panel2.Controls.Add(_historyGrid);
        _split.Panel2.Controls.Add(_historyTitle);

        _grid.AllowUserToAddRows = false;
        _grid.AllowUserToDeleteRows = false;
        _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _grid.BackgroundColor = SystemColors.Window;
        _grid.Dock = DockStyle.Fill;
        _grid.Name = "_grid";
        _grid.ReadOnly = true;
        _grid.RowHeadersVisible = false;
        _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _historyGrid.AllowUserToAddRows = false;
        _historyGrid.AllowUserToDeleteRows = false;
        _historyGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _historyGrid.BackgroundColor = SystemColors.Window;
        _historyGrid.Dock = DockStyle.Fill;
        _historyGrid.Name = "_historyGrid";
        _historyGrid.ReadOnly = true;
        _historyGrid.RowHeadersVisible = false;
        _historyGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _historyTitle.Dock = DockStyle.Top;
        _historyTitle.Font = new Font("Segoe UI Semibold", 12F);
        _historyTitle.Height = 35;
        _historyTitle.Text = "Lịch sử mua hàng";
        _historyTitle.TextAlign = ContentAlignment.MiddleLeft;

        _toolbar.Controls.AddRange(new Control[] { _lblSearch, _search, _btnSearch, _btnAll });
        _toolbar.Dock = DockStyle.Top;
        _toolbar.Height = 52;
        _toolbar.Name = "_toolbar";
        _toolbar.Padding = new Padding(5);
        _lblSearch.Size = new Size(90, 32);
        _lblSearch.Text = "Tìm khách";
        _lblSearch.TextAlign = ContentAlignment.MiddleLeft;
        _search.Name = "_search";
        _search.Size = new Size(200, 31);
        _btnSearch.AutoSize = true;
        _btnSearch.Text = "Tìm";
        _btnAll.AutoSize = true;
        _btnAll.Text = "Tất cả";

        _editor.ColumnCount = 2;
        _editor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        _editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _editor.Controls.Add(_lblFullName, 0, 0);
        _editor.Controls.Add(_fullName, 1, 0);
        _editor.Controls.Add(_lblPhone, 0, 1);
        _editor.Controls.Add(_phone, 1, 1);
        _editor.Controls.Add(_lblAddress, 0, 2);
        _editor.Controls.Add(_address, 1, 2);
        _editor.Controls.Add(_lblPoints, 0, 3);
        _editor.Controls.Add(_points, 1, 3);
        _editor.Controls.Add(_buttonPanel, 0, 4);
        _editor.Dock = DockStyle.Right;
        _editor.Name = "_editor";
        _editor.Padding = new Padding(15);
        _editor.RowCount = 6;
        _editor.SetColumnSpan(_buttonPanel, 2);
        _editor.Width = 390;
        _lblFullName.Text = "Họ tên";
        _lblFullName.TextAlign = ContentAlignment.MiddleLeft;
        _lblFullName.Dock = DockStyle.Fill;
        _fullName.Dock = DockStyle.Fill;
        _fullName.Name = "_fullName";
        _lblPhone.Text = "Điện thoại";
        _lblPhone.TextAlign = ContentAlignment.MiddleLeft;
        _lblPhone.Dock = DockStyle.Fill;
        _phone.Dock = DockStyle.Fill;
        _phone.Name = "_phone";
        _lblAddress.Text = "Địa chỉ";
        _lblAddress.TextAlign = ContentAlignment.MiddleLeft;
        _lblAddress.Dock = DockStyle.Fill;
        _address.Dock = DockStyle.Fill;
        _address.Name = "_address";
        _lblPoints.Text = "Điểm";
        _lblPoints.TextAlign = ContentAlignment.MiddleLeft;
        _lblPoints.Dock = DockStyle.Fill;
        _points.Dock = DockStyle.Fill;
        _points.Maximum = 1000000;
        _points.Name = "_points";

        _buttonPanel.AutoSize = true;
        _buttonPanel.Controls.AddRange(new Control[] { _btnAdd, _btnUpdate, _btnDelete, _btnAddPoints, _btnClear });
        _buttonPanel.Dock = DockStyle.Fill;
        _buttonPanel.Name = "_buttonPanel";
        _btnAdd.AutoSize = true;
        _btnAdd.Text = "Thêm";
        _btnUpdate.AutoSize = true;
        _btnUpdate.Text = "Cập nhật";
        _btnDelete.AutoSize = true;
        _btnDelete.Text = "Xóa";
        _btnAddPoints.AutoSize = true;
        _btnAddPoints.Text = "Cộng điểm";
        _btnClear.AutoSize = true;
        _btnClear.Text = "Làm mới";

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1200, 750);
        Controls.Add(_split);
        Controls.Add(_editor);
        Controls.Add(_toolbar);
        Font = new Font("Segoe UI", 10F);
        Name = "CustomerManagementForm";
        Text = "Quản lý khách hàng";
        _split.Panel1.ResumeLayout(false);
        _split.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_split).EndInit();
        _split.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        ((System.ComponentModel.ISupportInitialize)_historyGrid).EndInit();
        ((System.ComponentModel.ISupportInitialize)_points).EndInit();
        _toolbar.ResumeLayout(false);
        _toolbar.PerformLayout();
        _editor.ResumeLayout(false);
        _editor.PerformLayout();
        _buttonPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private SplitContainer _split;
    private DataGridView _grid;
    private DataGridView _historyGrid;
    private Label _historyTitle;
    private FlowLayoutPanel _toolbar;
    private Label _lblSearch;
    private TextBox _search;
    private Button _btnSearch;
    private Button _btnAll;
    private TableLayoutPanel _editor;
    private Label _lblFullName;
    private TextBox _fullName;
    private Label _lblPhone;
    private TextBox _phone;
    private Label _lblAddress;
    private TextBox _address;
    private Label _lblPoints;
    private NumericUpDown _points;
    private FlowLayoutPanel _buttonPanel;
    private Button _btnAdd;
    private Button _btnUpdate;
    private Button _btnDelete;
    private Button _btnAddPoints;
    private Button _btnClear;
}
