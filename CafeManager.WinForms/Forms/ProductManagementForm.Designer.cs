#nullable disable

namespace CafeManager.WinForms.Forms;

partial class ProductManagementForm
{
    private System.ComponentModel.IContainer components;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        _toolbar = new FlowLayoutPanel();
        _searchLabel = new Label();
        _search = new TextBox();
        _filterCategoryLabel = new Label();
        _filterCategory = new ComboBox();
        _filterButton = new Button();
        _showAllButton = new Button();
        _grid = new DataGridView();
        _editor = new TableLayoutPanel();
        _nameLabel = new Label();
        _name = new TextBox();
        _priceLabel = new Label();
        _price = new NumericUpDown();
        _categoryLabel = new Label();
        _category = new ComboBox();
        _available = new CheckBox();
        _imagePathLabel = new Label();
        _imagePath = new TextBox();
        _chooseImageButton = new Button();
        _picture = new PictureBox();
        _editorButtons = new FlowLayoutPanel();
        _addButton = new Button();
        _updateButton = new Button();
        _stopSellingButton = new Button();
        _deleteButton = new Button();
        _clearButton = new Button();
        _toolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        _editor.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_price).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_picture).BeginInit();
        _editorButtons.SuspendLayout();
        SuspendLayout();
        // 
        // _toolbar
        // 
        _toolbar.AutoSize = true;
        _toolbar.Controls.Add(_searchLabel);
        _toolbar.Controls.Add(_search);
        _toolbar.Controls.Add(_filterCategoryLabel);
        _toolbar.Controls.Add(_filterCategory);
        _toolbar.Controls.Add(_filterButton);
        _toolbar.Controls.Add(_showAllButton);
        _toolbar.Dock = DockStyle.Top;
        _toolbar.Location = new Point(0, 0);
        _toolbar.Name = "_toolbar";
        _toolbar.Padding = new Padding(5);
        _toolbar.Size = new Size(1180, 47);
        _toolbar.TabIndex = 0;
        _toolbar.WrapContents = true;
        // 
        // _searchLabel
        // 
        _searchLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _searchLabel.Location = new Point(10, 10);
        _searchLabel.Margin = new Padding(5);
        _searchLabel.Name = "_searchLabel";
        _searchLabel.Size = new Size(70, 30);
        _searchLabel.TabIndex = 0;
        _searchLabel.Text = "Tìm món";
        _searchLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _search
        // 
        _search.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _search.Location = new Point(90, 10);
        _search.Margin = new Padding(5);
        _search.Name = "_search";
        _search.Size = new Size(220, 25);
        _search.TabIndex = 1;
        // 
        // _filterCategoryLabel
        // 
        _filterCategoryLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _filterCategoryLabel.Location = new Point(320, 10);
        _filterCategoryLabel.Margin = new Padding(5);
        _filterCategoryLabel.Name = "_filterCategoryLabel";
        _filterCategoryLabel.Size = new Size(80, 30);
        _filterCategoryLabel.TabIndex = 2;
        _filterCategoryLabel.Text = "Danh mục";
        _filterCategoryLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _filterCategory
        // 
        _filterCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        _filterCategory.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _filterCategory.FormattingEnabled = true;
        _filterCategory.Location = new Point(410, 10);
        _filterCategory.Margin = new Padding(5);
        _filterCategory.Name = "_filterCategory";
        _filterCategory.Size = new Size(220, 25);
        _filterCategory.TabIndex = 3;
        // 
        // _filterButton
        // 
        _filterButton.FlatStyle = FlatStyle.Flat;
        _filterButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _filterButton.Location = new Point(640, 8);
        _filterButton.Margin = new Padding(5, 3, 5, 3);
        _filterButton.Name = "_filterButton";
        _filterButton.Size = new Size(90, 34);
        _filterButton.TabIndex = 4;
        _filterButton.Text = "Lọc";
        _filterButton.UseVisualStyleBackColor = true;
        // 
        // _showAllButton
        // 
        _showAllButton.FlatStyle = FlatStyle.Flat;
        _showAllButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _showAllButton.Location = new Point(740, 8);
        _showAllButton.Margin = new Padding(5, 3, 5, 3);
        _showAllButton.Name = "_showAllButton";
        _showAllButton.Size = new Size(90, 34);
        _showAllButton.TabIndex = 5;
        _showAllButton.Text = "Tất cả";
        _showAllButton.UseVisualStyleBackColor = true;
        // 
        // _grid
        // 
        _grid.AllowUserToAddRows = false;
        _grid.AllowUserToDeleteRows = false;
        _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _grid.BackgroundColor = SystemColors.Window;
        _grid.BorderStyle = BorderStyle.Fixed3D;
        _grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        _grid.Dock = DockStyle.Fill;
        _grid.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _grid.Location = new Point(0, 47);
        _grid.MultiSelect = false;
        _grid.Name = "_grid";
        _grid.ReadOnly = true;
        _grid.RowHeadersVisible = false;
        _grid.RowTemplate.Height = 25;
        _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _grid.Size = new Size(760, 653);
        _grid.TabIndex = 1;
        // 
        // _editor
        // 
        _editor.AutoScroll = true;
        _editor.BackColor = Color.WhiteSmoke;
        _editor.ColumnCount = 2;
        _editor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
        _editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _editor.Controls.Add(_nameLabel, 0, 0);
        _editor.Controls.Add(_name, 1, 0);
        _editor.Controls.Add(_priceLabel, 0, 1);
        _editor.Controls.Add(_price, 1, 1);
        _editor.Controls.Add(_categoryLabel, 0, 2);
        _editor.Controls.Add(_category, 1, 2);
        _editor.Controls.Add(_available, 1, 3);
        _editor.Controls.Add(_imagePathLabel, 0, 4);
        _editor.Controls.Add(_imagePath, 1, 4);
        _editor.Controls.Add(_chooseImageButton, 0, 5);
        _editor.Controls.Add(_picture, 1, 5);
        _editor.Controls.Add(_editorButtons, 0, 7);
        _editor.Dock = DockStyle.Right;
        _editor.Location = new Point(760, 47);
        _editor.Name = "_editor";
        _editor.Padding = new Padding(12);
        _editor.RowCount = 9;
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 190F));
        _editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
        _editor.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        _editor.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _editor.Size = new Size(420, 653);
        _editor.TabIndex = 2;
        // 
        // _nameLabel
        // 
        _nameLabel.Dock = DockStyle.Fill;
        _nameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _nameLabel.Location = new Point(17, 17);
        _nameLabel.Margin = new Padding(5);
        _nameLabel.Name = "_nameLabel";
        _nameLabel.Size = new Size(115, 37);
        _nameLabel.TabIndex = 0;
        _nameLabel.Text = "Tên món";
        _nameLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _name
        // 
        _name.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        _name.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _name.Location = new Point(142, 23);
        _name.Margin = new Padding(5);
        _name.Name = "_name";
        _name.Size = new Size(261, 25);
        _name.TabIndex = 1;
        // 
        // _priceLabel
        // 
        _priceLabel.Dock = DockStyle.Fill;
        _priceLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _priceLabel.Location = new Point(17, 64);
        _priceLabel.Margin = new Padding(5);
        _priceLabel.Name = "_priceLabel";
        _priceLabel.Size = new Size(115, 37);
        _priceLabel.TabIndex = 2;
        _priceLabel.Text = "Giá bán";
        _priceLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _price
        // 
        _price.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        _price.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _price.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
        _price.Location = new Point(142, 70);
        _price.Margin = new Padding(5);
        _price.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
        _price.Name = "_price";
        _price.Size = new Size(261, 25);
        _price.TabIndex = 3;
        _price.ThousandsSeparator = true;
        // 
        // _categoryLabel
        // 
        _categoryLabel.Dock = DockStyle.Fill;
        _categoryLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _categoryLabel.Location = new Point(17, 111);
        _categoryLabel.Margin = new Padding(5);
        _categoryLabel.Name = "_categoryLabel";
        _categoryLabel.Size = new Size(115, 37);
        _categoryLabel.TabIndex = 4;
        _categoryLabel.Text = "Danh mục";
        _categoryLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _category
        // 
        _category.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        _category.DropDownStyle = ComboBoxStyle.DropDownList;
        _category.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _category.FormattingEnabled = true;
        _category.Location = new Point(142, 117);
        _category.Margin = new Padding(5);
        _category.Name = "_category";
        _category.Size = new Size(261, 25);
        _category.TabIndex = 5;
        // 
        // _available
        // 
        _available.Anchor = AnchorStyles.Left;
        _available.AutoSize = true;
        _available.Checked = true;
        _available.CheckState = CheckState.Checked;
        _available.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _available.Location = new Point(142, 165);
        _available.Margin = new Padding(5);
        _available.Name = "_available";
        _available.Size = new Size(79, 23);
        _available.TabIndex = 6;
        _available.Text = "Còn bán";
        _available.UseVisualStyleBackColor = true;
        // 
        // _imagePathLabel
        // 
        _imagePathLabel.Dock = DockStyle.Fill;
        _imagePathLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _imagePathLabel.Location = new Point(17, 203);
        _imagePathLabel.Margin = new Padding(5);
        _imagePathLabel.Name = "_imagePathLabel";
        _imagePathLabel.Size = new Size(115, 37);
        _imagePathLabel.TabIndex = 7;
        _imagePathLabel.Text = "Đường dẫn ảnh";
        _imagePathLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _imagePath
        // 
        _imagePath.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        _imagePath.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _imagePath.Location = new Point(142, 209);
        _imagePath.Margin = new Padding(5);
        _imagePath.Name = "_imagePath";
        _imagePath.Size = new Size(261, 25);
        _imagePath.TabIndex = 8;
        // 
        // _chooseImageButton
        // 
        _chooseImageButton.FlatStyle = FlatStyle.Flat;
        _chooseImageButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _chooseImageButton.Location = new Point(17, 250);
        _chooseImageButton.Margin = new Padding(5);
        _chooseImageButton.Name = "_chooseImageButton";
        _chooseImageButton.Size = new Size(115, 36);
        _chooseImageButton.TabIndex = 9;
        _chooseImageButton.Text = "Chọn hình";
        _chooseImageButton.UseVisualStyleBackColor = true;
        // 
        // _picture
        // 
        _picture.BorderStyle = BorderStyle.FixedSingle;
        _picture.Dock = DockStyle.Fill;
        _picture.Location = new Point(142, 250);
        _picture.Margin = new Padding(5);
        _picture.Name = "_picture";
        _picture.Size = new Size(261, 180);
        _picture.SizeMode = PictureBoxSizeMode.Zoom;
        _picture.TabIndex = 10;
        _picture.TabStop = false;
        // 
        // _editorButtons
        // 
        _editorButtons.AutoSize = true;
        _editor.SetColumnSpan(_editorButtons, 2);
        _editorButtons.Controls.Add(_addButton);
        _editorButtons.Controls.Add(_updateButton);
        _editorButtons.Controls.Add(_stopSellingButton);
        _editorButtons.Controls.Add(_deleteButton);
        _editorButtons.Controls.Add(_clearButton);
        _editorButtons.Dock = DockStyle.Fill;
        _editorButtons.Location = new Point(15, 442);
        _editorButtons.Name = "_editorButtons";
        _editorButtons.Size = new Size(390, 84);
        _editorButtons.TabIndex = 11;
        _editorButtons.WrapContents = true;
        // 
        // _addButton
        // 
        _addButton.FlatStyle = FlatStyle.Flat;
        _addButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _addButton.Location = new Point(5, 5);
        _addButton.Margin = new Padding(5);
        _addButton.Name = "_addButton";
        _addButton.Size = new Size(100, 36);
        _addButton.TabIndex = 0;
        _addButton.Text = "Thêm";
        _addButton.UseVisualStyleBackColor = true;
        // 
        // _updateButton
        // 
        _updateButton.FlatStyle = FlatStyle.Flat;
        _updateButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _updateButton.Location = new Point(115, 5);
        _updateButton.Margin = new Padding(5);
        _updateButton.Name = "_updateButton";
        _updateButton.Size = new Size(100, 36);
        _updateButton.TabIndex = 1;
        _updateButton.Text = "Cập nhật";
        _updateButton.UseVisualStyleBackColor = true;
        // 
        // _stopSellingButton
        // 
        _stopSellingButton.FlatStyle = FlatStyle.Flat;
        _stopSellingButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _stopSellingButton.Location = new Point(225, 5);
        _stopSellingButton.Margin = new Padding(5);
        _stopSellingButton.Name = "_stopSellingButton";
        _stopSellingButton.Size = new Size(110, 36);
        _stopSellingButton.TabIndex = 2;
        _stopSellingButton.Text = "Ngừng bán";
        _stopSellingButton.UseVisualStyleBackColor = true;
        // 
        // _deleteButton
        // 
        _deleteButton.FlatStyle = FlatStyle.Flat;
        _deleteButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _deleteButton.Location = new Point(5, 51);
        _deleteButton.Margin = new Padding(5);
        _deleteButton.Name = "_deleteButton";
        _deleteButton.Size = new Size(100, 36);
        _deleteButton.TabIndex = 3;
        _deleteButton.Text = "Xóa";
        _deleteButton.UseVisualStyleBackColor = true;
        // 
        // _clearButton
        // 
        _clearButton.FlatStyle = FlatStyle.Flat;
        _clearButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _clearButton.Location = new Point(115, 51);
        _clearButton.Margin = new Padding(5);
        _clearButton.Name = "_clearButton";
        _clearButton.Size = new Size(100, 36);
        _clearButton.TabIndex = 4;
        _clearButton.Text = "Làm mới";
        _clearButton.UseVisualStyleBackColor = true;
        // 
        // ProductManagementForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1180, 700);
        Controls.Add(_grid);
        Controls.Add(_editor);
        Controls.Add(_toolbar);
        MinimumSize = new Size(1000, 620);
        Name = "ProductManagementForm";
        Text = "Quản lý đồ uống";
        _toolbar.ResumeLayout(false);
        _toolbar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        _editor.ResumeLayout(false);
        _editor.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_price).EndInit();
        ((System.ComponentModel.ISupportInitialize)_picture).EndInit();
        _editorButtons.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private FlowLayoutPanel _toolbar;
    private Label _searchLabel;
    private TextBox _search;
    private Label _filterCategoryLabel;
    private ComboBox _filterCategory;
    private Button _filterButton;
    private Button _showAllButton;
    private DataGridView _grid;
    private TableLayoutPanel _editor;
    private Label _nameLabel;
    private TextBox _name;
    private Label _priceLabel;
    private NumericUpDown _price;
    private Label _categoryLabel;
    private ComboBox _category;
    private CheckBox _available;
    private Label _imagePathLabel;
    private TextBox _imagePath;
    private Button _chooseImageButton;
    private PictureBox _picture;
    private FlowLayoutPanel _editorButtons;
    private Button _addButton;
    private Button _updateButton;
    private Button _stopSellingButton;
    private Button _deleteButton;
    private Button _clearButton;
}
