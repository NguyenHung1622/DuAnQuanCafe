#nullable disable

namespace CafeManager.WinForms.Forms;

partial class CategoryManagementForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        _grid = new DataGridView();
        _toolbar = new FlowLayoutPanel();
        _lblSearch = new Label();
        _search = new TextBox();
        _btnSearch = new Button();
        _btnAll = new Button();
        _editor = new TableLayoutPanel();
        _lblName = new Label();
        _name = new TextBox();
        _lblDescription = new Label();
        _description = new TextBox();
        _buttonPanel = new FlowLayoutPanel();
        _btnAdd = new Button();
        _btnUpdate = new Button();
        _btnDelete = new Button();
        _btnClear = new Button();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        _toolbar.SuspendLayout();
        _editor.SuspendLayout();
        _buttonPanel.SuspendLayout();
        SuspendLayout();
        // 
        // _grid
        // 
        _grid.AllowUserToAddRows = false;
        _grid.AllowUserToDeleteRows = false;
        _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _grid.BackgroundColor = SystemColors.Window;
        _grid.ColumnHeadersHeight = 29;
        _grid.Dock = DockStyle.Fill;
        _grid.Location = new Point(0, 52);
        _grid.MultiSelect = false;
        _grid.Name = "_grid";
        _grid.ReadOnly = true;
        _grid.RowHeadersVisible = false;
        _grid.RowHeadersWidth = 51;
        _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _grid.Size = new Size(610, 598);
        _grid.TabIndex = 0;
        // 
        // _toolbar
        // 
        _toolbar.Controls.Add(_lblSearch);
        _toolbar.Controls.Add(_search);
        _toolbar.Controls.Add(_btnSearch);
        _toolbar.Controls.Add(_btnAll);
        _toolbar.Dock = DockStyle.Top;
        _toolbar.Location = new Point(0, 0);
        _toolbar.Name = "_toolbar";
        _toolbar.Padding = new Padding(5);
        _toolbar.Size = new Size(1000, 52);
        _toolbar.TabIndex = 2;
        // 
        // _lblSearch
        // 
        _lblSearch.Location = new Point(8, 5);
        _lblSearch.Name = "_lblSearch";
        _lblSearch.Size = new Size(115, 32);
        _lblSearch.TabIndex = 0;
        _lblSearch.Text = "Tìm danh mục";
        _lblSearch.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _search
        // 
        _search.Location = new Point(129, 8);
        _search.Name = "_search";
        _search.Size = new Size(220, 30);
        _search.TabIndex = 1;
        // 
        // _btnSearch
        // 
        _btnSearch.AutoSize = true;
        _btnSearch.Location = new Point(355, 8);
        _btnSearch.Name = "_btnSearch";
        _btnSearch.Size = new Size(75, 33);
        _btnSearch.TabIndex = 2;
        _btnSearch.Text = "Tìm";
        _btnSearch.UseVisualStyleBackColor = true;
        // 
        // _btnAll
        // 
        _btnAll.AutoSize = true;
        _btnAll.Location = new Point(436, 8);
        _btnAll.Name = "_btnAll";
        _btnAll.Size = new Size(75, 33);
        _btnAll.TabIndex = 3;
        _btnAll.Text = "Tất cả";
        _btnAll.UseVisualStyleBackColor = true;
        // 
        // _editor
        // 
        _editor.ColumnCount = 2;
        _editor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        _editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _editor.Controls.Add(_lblName, 0, 0);
        _editor.Controls.Add(_name, 1, 0);
        _editor.Controls.Add(_lblDescription, 0, 1);
        _editor.Controls.Add(_description, 1, 1);
        _editor.Controls.Add(_buttonPanel, 0, 2);
        _editor.Dock = DockStyle.Right;
        _editor.Location = new Point(610, 52);
        _editor.Name = "_editor";
        _editor.Padding = new Padding(15);
        _editor.RowCount = 4;
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _editor.Size = new Size(390, 598);
        _editor.TabIndex = 1;
        // 
        // _lblName
        // 
        _lblName.Dock = DockStyle.Fill;
        _lblName.Location = new Point(18, 15);
        _lblName.Name = "_lblName";
        _lblName.Size = new Size(114, 20);
        _lblName.TabIndex = 0;
        _lblName.Text = "Tên danh mục";
        _lblName.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _name
        // 
        _name.Dock = DockStyle.Fill;
        _name.Location = new Point(138, 18);
        _name.Name = "_name";
        _name.Size = new Size(234, 30);
        _name.TabIndex = 1;
        // 
        // _lblDescription
        // 
        _lblDescription.Dock = DockStyle.Fill;
        _lblDescription.Location = new Point(18, 35);
        _lblDescription.Name = "_lblDescription";
        _lblDescription.Size = new Size(114, 20);
        _lblDescription.TabIndex = 2;
        _lblDescription.Text = "Mô tả";
        _lblDescription.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _description
        // 
        _description.Dock = DockStyle.Fill;
        _description.Location = new Point(138, 38);
        _description.Multiline = true;
        _description.Name = "_description";
        _description.Size = new Size(234, 14);
        _description.TabIndex = 3;
        // 
        // _buttonPanel
        // 
        _buttonPanel.AutoSize = true;
        _editor.SetColumnSpan(_buttonPanel, 2);
        _buttonPanel.Controls.Add(_btnAdd);
        _buttonPanel.Controls.Add(_btnUpdate);
        _buttonPanel.Controls.Add(_btnDelete);
        _buttonPanel.Controls.Add(_btnClear);
        _buttonPanel.Dock = DockStyle.Fill;
        _buttonPanel.Location = new Point(18, 58);
        _buttonPanel.Name = "_buttonPanel";
        _buttonPanel.Size = new Size(354, 14);
        _buttonPanel.TabIndex = 4;
        // 
        // _btnAdd
        // 
        _btnAdd.AutoSize = true;
        _btnAdd.Location = new Point(3, 3);
        _btnAdd.Name = "_btnAdd";
        _btnAdd.Size = new Size(75, 33);
        _btnAdd.TabIndex = 0;
        _btnAdd.Text = "Thêm";
        // 
        // _btnUpdate
        // 
        _btnUpdate.AutoSize = true;
        _btnUpdate.Location = new Point(84, 3);
        _btnUpdate.Name = "_btnUpdate";
        _btnUpdate.Size = new Size(90, 33);
        _btnUpdate.TabIndex = 1;
        _btnUpdate.Text = "Cập nhật";
        // 
        // _btnDelete
        // 
        _btnDelete.AutoSize = true;
        _btnDelete.Location = new Point(180, 3);
        _btnDelete.Name = "_btnDelete";
        _btnDelete.Size = new Size(75, 33);
        _btnDelete.TabIndex = 2;
        _btnDelete.Text = "Xóa";
        // 
        // _btnClear
        // 
        _btnClear.AutoSize = true;
        _btnClear.Location = new Point(261, 3);
        _btnClear.Name = "_btnClear";
        _btnClear.Size = new Size(86, 33);
        _btnClear.TabIndex = 3;
        _btnClear.Text = "Làm mới";
        // 
        // CategoryManagementForm
        // 
        AutoScaleDimensions = new SizeF(9F, 23F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 650);
        Controls.Add(_grid);
        Controls.Add(_editor);
        Controls.Add(_toolbar);
        Font = new Font("Segoe UI", 10F);
        Name = "CategoryManagementForm";
        Text = "Quản lý danh mục";
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        _toolbar.ResumeLayout(false);
        _toolbar.PerformLayout();
        _editor.ResumeLayout(false);
        _editor.PerformLayout();
        _buttonPanel.ResumeLayout(false);
        _buttonPanel.PerformLayout();
        ResumeLayout(false);
    }

    private DataGridView _grid;
    private FlowLayoutPanel _toolbar;
    private Label _lblSearch;
    private TextBox _search;
    private Button _btnSearch;
    private Button _btnAll;
    private TableLayoutPanel _editor;
    private Label _lblName;
    private TextBox _name;
    private Label _lblDescription;
    private TextBox _description;
    private FlowLayoutPanel _buttonPanel;
    private Button _btnAdd;
    private Button _btnUpdate;
    private Button _btnDelete;
    private Button _btnClear;
}
