#nullable disable

namespace CafeManager.WinForms.Forms;

partial class SalesForm
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
        _mainLayout = new TableLayoutPanel();
        _tablesGroup = new GroupBox();
        _tablesPanel = new FlowLayoutPanel();
        _productsGroup = new GroupBox();
        _productsLayout = new TableLayoutPanel();
        _productToolbar = new FlowLayoutPanel();
        _productSearch = new TextBox();
        _categoryFilter = new ComboBox();
        _filterButton = new Button();
        _addProductButton = new Button();
        _productsGrid = new DataGridView();
        _invoiceGroup = new GroupBox();
        _invoiceLayout = new TableLayoutPanel();
        _selectedTableLabel = new Label();
        _detailsGrid = new DataGridView();
        _invoiceBottom = new FlowLayoutPanel();
        _increaseButton = new Button();
        _decreaseButton = new Button();
        _removeProductButton = new Button();
        _transferTableButton = new Button();
        _mergeInvoiceButton = new Button();
        _customerLabel = new Label();
        _customer = new ComboBox();
        _discountLabel = new Label();
        _discount = new NumericUpDown();
        _applyButton = new Button();
        _subtotalLabel = new Label();
        _totalLabel = new Label();
        _payButton = new Button();
        _printButton = new Button();
        _mainLayout.SuspendLayout();
        _tablesGroup.SuspendLayout();
        _productsGroup.SuspendLayout();
        _productsLayout.SuspendLayout();
        _productToolbar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_productsGrid).BeginInit();
        _invoiceGroup.SuspendLayout();
        _invoiceLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_detailsGrid).BeginInit();
        _invoiceBottom.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_discount).BeginInit();
        SuspendLayout();
        // 
        // _mainLayout
        // 
        _mainLayout.ColumnCount = 3;
        _mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
        _mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
        _mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        _mainLayout.Controls.Add(_tablesGroup, 0, 0);
        _mainLayout.Controls.Add(_productsGroup, 1, 0);
        _mainLayout.Controls.Add(_invoiceGroup, 2, 0);
        _mainLayout.Dock = DockStyle.Fill;
        _mainLayout.Location = new Point(0, 0);
        _mainLayout.Name = "_mainLayout";
        _mainLayout.RowCount = 1;
        _mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _mainLayout.Size = new Size(1350, 750);
        _mainLayout.TabIndex = 0;
        // 
        // _tablesGroup
        // 
        _tablesGroup.Controls.Add(_tablesPanel);
        _tablesGroup.Dock = DockStyle.Fill;
        _tablesGroup.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _tablesGroup.Location = new Point(3, 3);
        _tablesGroup.Name = "_tablesGroup";
        _tablesGroup.Padding = new Padding(8);
        _tablesGroup.Size = new Size(318, 744);
        _tablesGroup.TabIndex = 0;
        _tablesGroup.TabStop = false;
        _tablesGroup.Text = "Danh sách bàn";
        // 
        // _tablesPanel
        // 
        _tablesPanel.AutoScroll = true;
        _tablesPanel.BackColor = Color.White;
        _tablesPanel.Dock = DockStyle.Fill;
        _tablesPanel.Location = new Point(8, 26);
        _tablesPanel.Name = "_tablesPanel";
        _tablesPanel.Padding = new Padding(5);
        _tablesPanel.Size = new Size(302, 710);
        _tablesPanel.TabIndex = 0;
        // 
        // _productsGroup
        // 
        _productsGroup.Controls.Add(_productsLayout);
        _productsGroup.Dock = DockStyle.Fill;
        _productsGroup.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _productsGroup.Location = new Point(327, 3);
        _productsGroup.Name = "_productsGroup";
        _productsGroup.Padding = new Padding(6);
        _productsGroup.Size = new Size(480, 744);
        _productsGroup.TabIndex = 1;
        _productsGroup.TabStop = false;
        _productsGroup.Text = "Danh sách món";
        // 
        // _productsLayout
        // 
        _productsLayout.ColumnCount = 1;
        _productsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _productsLayout.Controls.Add(_productToolbar, 0, 0);
        _productsLayout.Controls.Add(_productsGrid, 0, 1);
        _productsLayout.Dock = DockStyle.Fill;
        _productsLayout.Location = new Point(6, 24);
        _productsLayout.Name = "_productsLayout";
        _productsLayout.RowCount = 2;
        _productsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
        _productsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _productsLayout.Size = new Size(468, 714);
        _productsLayout.TabIndex = 0;
        // 
        // _productToolbar
        // 
        _productToolbar.Controls.Add(_productSearch);
        _productToolbar.Controls.Add(_categoryFilter);
        _productToolbar.Controls.Add(_filterButton);
        _productToolbar.Controls.Add(_addProductButton);
        _productToolbar.Dock = DockStyle.Fill;
        _productToolbar.Location = new Point(3, 3);
        _productToolbar.Name = "_productToolbar";
        _productToolbar.Padding = new Padding(3);
        _productToolbar.Size = new Size(462, 86);
        _productToolbar.TabIndex = 0;
        _productToolbar.WrapContents = true;
        // 
        // _productSearch
        // 
        _productSearch.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _productSearch.Location = new Point(8, 8);
        _productSearch.Margin = new Padding(5);
        _productSearch.Name = "_productSearch";
        _productSearch.PlaceholderText = "Tìm món...";
        _productSearch.Size = new Size(190, 25);
        _productSearch.TabIndex = 0;
        // 
        // _categoryFilter
        // 
        _categoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        _categoryFilter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _categoryFilter.FormattingEnabled = true;
        _categoryFilter.Location = new Point(208, 8);
        _categoryFilter.Margin = new Padding(5);
        _categoryFilter.Name = "_categoryFilter";
        _categoryFilter.Size = new Size(190, 25);
        _categoryFilter.TabIndex = 1;
        // 
        // _filterButton
        // 
        _filterButton.FlatStyle = FlatStyle.Flat;
        _filterButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _filterButton.Location = new Point(8, 43);
        _filterButton.Margin = new Padding(5);
        _filterButton.Name = "_filterButton";
        _filterButton.Size = new Size(90, 36);
        _filterButton.TabIndex = 2;
        _filterButton.Text = "Lọc";
        _filterButton.UseVisualStyleBackColor = true;
        // 
        // _addProductButton
        // 
        _addProductButton.FlatStyle = FlatStyle.Flat;
        _addProductButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _addProductButton.Location = new Point(108, 43);
        _addProductButton.Margin = new Padding(5);
        _addProductButton.Name = "_addProductButton";
        _addProductButton.Size = new Size(105, 36);
        _addProductButton.TabIndex = 3;
        _addProductButton.Text = "Thêm món";
        _addProductButton.UseVisualStyleBackColor = true;
        // 
        // _productsGrid
        // 
        _productsGrid.AllowUserToAddRows = false;
        _productsGrid.AllowUserToDeleteRows = false;
        _productsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _productsGrid.BackgroundColor = SystemColors.Window;
        _productsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        _productsGrid.Dock = DockStyle.Fill;
        _productsGrid.Location = new Point(3, 95);
        _productsGrid.MultiSelect = false;
        _productsGrid.Name = "_productsGrid";
        _productsGrid.ReadOnly = true;
        _productsGrid.RowHeadersVisible = false;
        _productsGrid.RowTemplate.Height = 25;
        _productsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _productsGrid.Size = new Size(462, 616);
        _productsGrid.TabIndex = 1;
        // 
        // _invoiceGroup
        // 
        _invoiceGroup.Controls.Add(_invoiceLayout);
        _invoiceGroup.Dock = DockStyle.Fill;
        _invoiceGroup.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _invoiceGroup.Location = new Point(813, 3);
        _invoiceGroup.Name = "_invoiceGroup";
        _invoiceGroup.Padding = new Padding(6);
        _invoiceGroup.Size = new Size(534, 744);
        _invoiceGroup.TabIndex = 2;
        _invoiceGroup.TabStop = false;
        _invoiceGroup.Text = "Hóa đơn";
        // 
        // _invoiceLayout
        // 
        _invoiceLayout.ColumnCount = 1;
        _invoiceLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _invoiceLayout.Controls.Add(_selectedTableLabel, 0, 0);
        _invoiceLayout.Controls.Add(_detailsGrid, 0, 1);
        _invoiceLayout.Controls.Add(_invoiceBottom, 0, 2);
        _invoiceLayout.Dock = DockStyle.Fill;
        _invoiceLayout.Location = new Point(6, 24);
        _invoiceLayout.Name = "_invoiceLayout";
        _invoiceLayout.RowCount = 3;
        _invoiceLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        _invoiceLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _invoiceLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 230F));
        _invoiceLayout.Size = new Size(522, 714);
        _invoiceLayout.TabIndex = 0;
        // 
        // _selectedTableLabel
        // 
        _selectedTableLabel.BackColor = Color.AliceBlue;
        _selectedTableLabel.BorderStyle = BorderStyle.FixedSingle;
        _selectedTableLabel.Dock = DockStyle.Fill;
        _selectedTableLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
        _selectedTableLabel.Location = new Point(3, 3);
        _selectedTableLabel.Margin = new Padding(3);
        _selectedTableLabel.Name = "_selectedTableLabel";
        _selectedTableLabel.Size = new Size(516, 42);
        _selectedTableLabel.TabIndex = 0;
        _selectedTableLabel.Text = "Chưa chọn bàn";
        _selectedTableLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _detailsGrid
        // 
        _detailsGrid.AllowUserToAddRows = false;
        _detailsGrid.AllowUserToDeleteRows = false;
        _detailsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _detailsGrid.BackgroundColor = SystemColors.Window;
        _detailsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        _detailsGrid.Dock = DockStyle.Fill;
        _detailsGrid.Location = new Point(3, 51);
        _detailsGrid.MultiSelect = false;
        _detailsGrid.Name = "_detailsGrid";
        _detailsGrid.ReadOnly = true;
        _detailsGrid.RowHeadersVisible = false;
        _detailsGrid.RowTemplate.Height = 25;
        _detailsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _detailsGrid.Size = new Size(516, 430);
        _detailsGrid.TabIndex = 1;
        // 
        // _invoiceBottom
        // 
        _invoiceBottom.AutoScroll = true;
        _invoiceBottom.Controls.Add(_increaseButton);
        _invoiceBottom.Controls.Add(_decreaseButton);
        _invoiceBottom.Controls.Add(_removeProductButton);
        _invoiceBottom.Controls.Add(_transferTableButton);
        _invoiceBottom.Controls.Add(_mergeInvoiceButton);
        _invoiceBottom.Controls.Add(_customerLabel);
        _invoiceBottom.Controls.Add(_customer);
        _invoiceBottom.Controls.Add(_discountLabel);
        _invoiceBottom.Controls.Add(_discount);
        _invoiceBottom.Controls.Add(_applyButton);
        _invoiceBottom.Controls.Add(_subtotalLabel);
        _invoiceBottom.Controls.Add(_totalLabel);
        _invoiceBottom.Controls.Add(_payButton);
        _invoiceBottom.Controls.Add(_printButton);
        _invoiceBottom.Dock = DockStyle.Fill;
        _invoiceBottom.Location = new Point(3, 487);
        _invoiceBottom.Name = "_invoiceBottom";
        _invoiceBottom.Padding = new Padding(3);
        _invoiceBottom.Size = new Size(516, 224);
        _invoiceBottom.TabIndex = 2;
        _invoiceBottom.WrapContents = true;
        // 
        // _increaseButton
        // 
        _increaseButton.FlatStyle = FlatStyle.Flat;
        _increaseButton.Location = new Point(8, 8);
        _increaseButton.Margin = new Padding(5);
        _increaseButton.Name = "_increaseButton";
        _increaseButton.Size = new Size(110, 36);
        _increaseButton.TabIndex = 0;
        _increaseButton.Text = "+ Số lượng";
        _increaseButton.UseVisualStyleBackColor = true;
        // 
        // _decreaseButton
        // 
        _decreaseButton.FlatStyle = FlatStyle.Flat;
        _decreaseButton.Location = new Point(128, 8);
        _decreaseButton.Margin = new Padding(5);
        _decreaseButton.Name = "_decreaseButton";
        _decreaseButton.Size = new Size(110, 36);
        _decreaseButton.TabIndex = 1;
        _decreaseButton.Text = "- Số lượng";
        _decreaseButton.UseVisualStyleBackColor = true;
        // 
        // _removeProductButton
        // 
        _removeProductButton.FlatStyle = FlatStyle.Flat;
        _removeProductButton.Location = new Point(248, 8);
        _removeProductButton.Margin = new Padding(5);
        _removeProductButton.Name = "_removeProductButton";
        _removeProductButton.Size = new Size(100, 36);
        _removeProductButton.TabIndex = 2;
        _removeProductButton.Text = "Xóa món";
        _removeProductButton.UseVisualStyleBackColor = true;
        // 
        // _transferTableButton
        // 
        _transferTableButton.FlatStyle = FlatStyle.Flat;
        _transferTableButton.Location = new Point(358, 8);
        _transferTableButton.Margin = new Padding(5);
        _transferTableButton.Name = "_transferTableButton";
        _transferTableButton.Size = new Size(110, 36);
        _transferTableButton.TabIndex = 3;
        _transferTableButton.Text = "Chuyển bàn";
        _transferTableButton.UseVisualStyleBackColor = true;
        // 
        // _mergeInvoiceButton
        // 
        _mergeInvoiceButton.FlatStyle = FlatStyle.Flat;
        _mergeInvoiceButton.Location = new Point(8, 54);
        _mergeInvoiceButton.Margin = new Padding(5);
        _mergeInvoiceButton.Name = "_mergeInvoiceButton";
        _mergeInvoiceButton.Size = new Size(100, 36);
        _mergeInvoiceButton.TabIndex = 4;
        _mergeInvoiceButton.Text = "Gộp HĐ";
        _mergeInvoiceButton.UseVisualStyleBackColor = true;
        // 
        // _customerLabel
        // 
        _customerLabel.Location = new Point(118, 54);
        _customerLabel.Margin = new Padding(5);
        _customerLabel.Name = "_customerLabel";
        _customerLabel.Size = new Size(95, 30);
        _customerLabel.TabIndex = 5;
        _customerLabel.Text = "Khách hàng";
        _customerLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _customer
        // 
        _customer.DropDownStyle = ComboBoxStyle.DropDownList;
        _customer.FormattingEnabled = true;
        _customer.Location = new Point(223, 54);
        _customer.Margin = new Padding(5);
        _customer.Name = "_customer";
        _customer.Size = new Size(255, 25);
        _customer.TabIndex = 6;
        // 
        // _discountLabel
        // 
        _discountLabel.Location = new Point(8, 100);
        _discountLabel.Margin = new Padding(5);
        _discountLabel.Name = "_discountLabel";
        _discountLabel.Size = new Size(80, 30);
        _discountLabel.TabIndex = 7;
        _discountLabel.Text = "Giảm giá";
        _discountLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _discount
        // 
        _discount.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
        _discount.Location = new Point(98, 100);
        _discount.Margin = new Padding(5);
        _discount.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
        _discount.Name = "_discount";
        _discount.Size = new Size(145, 25);
        _discount.TabIndex = 8;
        _discount.ThousandsSeparator = true;
        // 
        // _applyButton
        // 
        _applyButton.FlatStyle = FlatStyle.Flat;
        _applyButton.Location = new Point(253, 98);
        _applyButton.Margin = new Padding(5, 3, 5, 3);
        _applyButton.Name = "_applyButton";
        _applyButton.Size = new Size(90, 34);
        _applyButton.TabIndex = 9;
        _applyButton.Text = "Áp dụng";
        _applyButton.UseVisualStyleBackColor = true;
        // 
        // _subtotalLabel
        // 
        _subtotalLabel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point);
        _subtotalLabel.Location = new Point(8, 140);
        _subtotalLabel.Margin = new Padding(5);
        _subtotalLabel.Name = "_subtotalLabel";
        _subtotalLabel.Size = new Size(225, 30);
        _subtotalLabel.TabIndex = 10;
        _subtotalLabel.Text = "Tạm tính: 0 đ";
        _subtotalLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _totalLabel
        // 
        _totalLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
        _totalLabel.ForeColor = Color.Firebrick;
        _totalLabel.Location = new Point(243, 140);
        _totalLabel.Margin = new Padding(5);
        _totalLabel.Name = "_totalLabel";
        _totalLabel.Size = new Size(235, 30);
        _totalLabel.TabIndex = 11;
        _totalLabel.Text = "Tổng: 0 đ";
        _totalLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _payButton
        // 
        _payButton.BackColor = Color.Honeydew;
        _payButton.FlatStyle = FlatStyle.Flat;
        _payButton.Location = new Point(8, 180);
        _payButton.Margin = new Padding(5);
        _payButton.Name = "_payButton";
        _payButton.Size = new Size(120, 36);
        _payButton.TabIndex = 12;
        _payButton.Text = "Thanh toán";
        _payButton.UseVisualStyleBackColor = false;
        // 
        // _printButton
        // 
        _printButton.FlatStyle = FlatStyle.Flat;
        _printButton.Location = new Point(138, 180);
        _printButton.Margin = new Padding(5);
        _printButton.Name = "_printButton";
        _printButton.Size = new Size(120, 36);
        _printButton.TabIndex = 13;
        _printButton.Text = "In hóa đơn";
        _printButton.UseVisualStyleBackColor = true;
        // 
        // SalesForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1350, 750);
        Controls.Add(_mainLayout);
        MinimumSize = new Size(1100, 650);
        Name = "SalesForm";
        Text = "Bán hàng";
        _mainLayout.ResumeLayout(false);
        _tablesGroup.ResumeLayout(false);
        _productsGroup.ResumeLayout(false);
        _productsLayout.ResumeLayout(false);
        _productToolbar.ResumeLayout(false);
        _productToolbar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_productsGrid).EndInit();
        _invoiceGroup.ResumeLayout(false);
        _invoiceLayout.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_detailsGrid).EndInit();
        _invoiceBottom.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_discount).EndInit();
        ResumeLayout(false);
    }

    private TableLayoutPanel _mainLayout;
    private GroupBox _tablesGroup;
    private FlowLayoutPanel _tablesPanel;
    private GroupBox _productsGroup;
    private TableLayoutPanel _productsLayout;
    private FlowLayoutPanel _productToolbar;
    private TextBox _productSearch;
    private ComboBox _categoryFilter;
    private Button _filterButton;
    private Button _addProductButton;
    private DataGridView _productsGrid;
    private GroupBox _invoiceGroup;
    private TableLayoutPanel _invoiceLayout;
    private Label _selectedTableLabel;
    private DataGridView _detailsGrid;
    private FlowLayoutPanel _invoiceBottom;
    private Button _increaseButton;
    private Button _decreaseButton;
    private Button _removeProductButton;
    private Button _transferTableButton;
    private Button _mergeInvoiceButton;
    private Label _customerLabel;
    private ComboBox _customer;
    private Label _discountLabel;
    private NumericUpDown _discount;
    private Button _applyButton;
    private Label _subtotalLabel;
    private Label _totalLabel;
    private Button _payButton;
    private Button _printButton;
}
