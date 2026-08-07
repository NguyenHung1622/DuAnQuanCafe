#nullable disable

using CafeManager.WinForms.Controls;

namespace CafeManager.WinForms.Forms;

partial class ReportsForm
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
        _fromLabel = new Label();
        _from = new DateTimePicker();
        _toLabel = new Label();
        _to = new DateTimePicker();
        _statisticsButton = new Button();
        _exportButton = new Button();
        _cards = new TableLayoutPanel();
        _todayRevenue = new Label();
        _monthRevenue = new Label();
        _yearRevenue = new Label();
        _openTables = new Label();
        _tabs = new TabControl();
        _dashboardTab = new TabPage();
        _chart = new RevenueChart();
        _revenueTab = new TabPage();
        _revenueGrid = new DataGridView();
        _topProductsTab = new TabPage();
        _topProductsGrid = new DataGridView();
        _toolbar.SuspendLayout();
        _cards.SuspendLayout();
        _tabs.SuspendLayout();
        _dashboardTab.SuspendLayout();
        _revenueTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_revenueGrid).BeginInit();
        _topProductsTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_topProductsGrid).BeginInit();
        SuspendLayout();
        // 
        // _toolbar
        // 
        _toolbar.AutoSize = true;
        _toolbar.Controls.Add(_fromLabel);
        _toolbar.Controls.Add(_from);
        _toolbar.Controls.Add(_toLabel);
        _toolbar.Controls.Add(_to);
        _toolbar.Controls.Add(_statisticsButton);
        _toolbar.Controls.Add(_exportButton);
        _toolbar.Dock = DockStyle.Top;
        _toolbar.Location = new Point(0, 0);
        _toolbar.Name = "_toolbar";
        _toolbar.Padding = new Padding(5);
        _toolbar.Size = new Size(1100, 47);
        _toolbar.TabIndex = 0;
        _toolbar.WrapContents = true;
        // 
        // _fromLabel
        // 
        _fromLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _fromLabel.Location = new Point(10, 10);
        _fromLabel.Margin = new Padding(5);
        _fromLabel.Name = "_fromLabel";
        _fromLabel.Size = new Size(70, 30);
        _fromLabel.TabIndex = 0;
        _fromLabel.Text = "Từ ngày";
        _fromLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _from
        // 
        _from.CustomFormat = "dd/MM/yyyy";
        _from.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _from.Format = DateTimePickerFormat.Custom;
        _from.Location = new Point(90, 10);
        _from.Margin = new Padding(5);
        _from.Name = "_from";
        _from.Size = new Size(145, 25);
        _from.TabIndex = 1;
        // 
        // _toLabel
        // 
        _toLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _toLabel.Location = new Point(245, 10);
        _toLabel.Margin = new Padding(5);
        _toLabel.Name = "_toLabel";
        _toLabel.Size = new Size(80, 30);
        _toLabel.TabIndex = 2;
        _toLabel.Text = "Đến ngày";
        _toLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // _to
        // 
        _to.CustomFormat = "dd/MM/yyyy";
        _to.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _to.Format = DateTimePickerFormat.Custom;
        _to.Location = new Point(335, 10);
        _to.Margin = new Padding(5);
        _to.Name = "_to";
        _to.Size = new Size(145, 25);
        _to.TabIndex = 3;
        // 
        // _statisticsButton
        // 
        _statisticsButton.FlatStyle = FlatStyle.Flat;
        _statisticsButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _statisticsButton.Location = new Point(490, 8);
        _statisticsButton.Margin = new Padding(5, 3, 5, 3);
        _statisticsButton.Name = "_statisticsButton";
        _statisticsButton.Size = new Size(100, 34);
        _statisticsButton.TabIndex = 4;
        _statisticsButton.Text = "Thống kê";
        _statisticsButton.UseVisualStyleBackColor = true;
        // 
        // _exportButton
        // 
        _exportButton.FlatStyle = FlatStyle.Flat;
        _exportButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _exportButton.Location = new Point(600, 8);
        _exportButton.Margin = new Padding(5, 3, 5, 3);
        _exportButton.Name = "_exportButton";
        _exportButton.Size = new Size(110, 34);
        _exportButton.TabIndex = 5;
        _exportButton.Text = "Xuất Excel";
        _exportButton.UseVisualStyleBackColor = true;
        // 
        // _cards
        // 
        _cards.ColumnCount = 4;
        _cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        _cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        _cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        _cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        _cards.Controls.Add(_todayRevenue, 0, 0);
        _cards.Controls.Add(_monthRevenue, 1, 0);
        _cards.Controls.Add(_yearRevenue, 2, 0);
        _cards.Controls.Add(_openTables, 3, 0);
        _cards.Dock = DockStyle.Top;
        _cards.Location = new Point(0, 47);
        _cards.Name = "_cards";
        _cards.Padding = new Padding(6);
        _cards.RowCount = 1;
        _cards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        _cards.Size = new Size(1100, 105);
        _cards.TabIndex = 1;
        // 
        // _todayRevenue
        // 
        _todayRevenue.BackColor = Color.Honeydew;
        _todayRevenue.BorderStyle = BorderStyle.FixedSingle;
        _todayRevenue.Dock = DockStyle.Fill;
        _todayRevenue.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
        _todayRevenue.Location = new Point(14, 14);
        _todayRevenue.Margin = new Padding(8);
        _todayRevenue.Name = "_todayRevenue";
        _todayRevenue.Size = new Size(255, 77);
        _todayRevenue.TabIndex = 0;
        _todayRevenue.Text = "Hôm nay\r\n0 đ";
        _todayRevenue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _monthRevenue
        // 
        _monthRevenue.BackColor = Color.AliceBlue;
        _monthRevenue.BorderStyle = BorderStyle.FixedSingle;
        _monthRevenue.Dock = DockStyle.Fill;
        _monthRevenue.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
        _monthRevenue.Location = new Point(287, 14);
        _monthRevenue.Margin = new Padding(8);
        _monthRevenue.Name = "_monthRevenue";
        _monthRevenue.Size = new Size(255, 77);
        _monthRevenue.TabIndex = 1;
        _monthRevenue.Text = "Tháng này\r\n0 đ";
        _monthRevenue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _yearRevenue
        // 
        _yearRevenue.BackColor = Color.LemonChiffon;
        _yearRevenue.BorderStyle = BorderStyle.FixedSingle;
        _yearRevenue.Dock = DockStyle.Fill;
        _yearRevenue.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
        _yearRevenue.Location = new Point(560, 14);
        _yearRevenue.Margin = new Padding(8);
        _yearRevenue.Name = "_yearRevenue";
        _yearRevenue.Size = new Size(255, 77);
        _yearRevenue.TabIndex = 2;
        _yearRevenue.Text = "Năm nay\r\n0 đ";
        _yearRevenue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _openTables
        // 
        _openTables.BackColor = Color.MistyRose;
        _openTables.BorderStyle = BorderStyle.FixedSingle;
        _openTables.Dock = DockStyle.Fill;
        _openTables.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
        _openTables.Location = new Point(833, 14);
        _openTables.Margin = new Padding(8);
        _openTables.Name = "_openTables";
        _openTables.Size = new Size(253, 77);
        _openTables.TabIndex = 3;
        _openTables.Text = "Bàn phục vụ\r\n0";
        _openTables.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // _tabs
        // 
        _tabs.Controls.Add(_dashboardTab);
        _tabs.Controls.Add(_revenueTab);
        _tabs.Controls.Add(_topProductsTab);
        _tabs.Dock = DockStyle.Fill;
        _tabs.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _tabs.Location = new Point(0, 152);
        _tabs.Name = "_tabs";
        _tabs.SelectedIndex = 0;
        _tabs.Size = new Size(1100, 548);
        _tabs.TabIndex = 2;
        // 
        // _dashboardTab
        // 
        _dashboardTab.Controls.Add(_chart);
        _dashboardTab.Location = new Point(4, 26);
        _dashboardTab.Name = "_dashboardTab";
        _dashboardTab.Padding = new Padding(8);
        _dashboardTab.Size = new Size(1092, 518);
        _dashboardTab.TabIndex = 0;
        _dashboardTab.Text = "Dashboard biểu đồ";
        _dashboardTab.UseVisualStyleBackColor = true;
        // 
        // _chart
        // 
        _chart.BackColor = Color.White;
        _chart.Dock = DockStyle.Fill;
        _chart.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        _chart.Location = new Point(8, 8);
        _chart.MinimumSize = new Size(400, 240);
        _chart.Name = "_chart";
        _chart.Size = new Size(1076, 502);
        _chart.TabIndex = 0;
        // 
        // _revenueTab
        // 
        _revenueTab.Controls.Add(_revenueGrid);
        _revenueTab.Location = new Point(4, 26);
        _revenueTab.Name = "_revenueTab";
        _revenueTab.Padding = new Padding(3);
        _revenueTab.Size = new Size(1092, 518);
        _revenueTab.TabIndex = 1;
        _revenueTab.Text = "Doanh thu theo ngày";
        _revenueTab.UseVisualStyleBackColor = true;
        // 
        // _revenueGrid
        // 
        _revenueGrid.AllowUserToAddRows = false;
        _revenueGrid.AllowUserToDeleteRows = false;
        _revenueGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _revenueGrid.BackgroundColor = SystemColors.Window;
        _revenueGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        _revenueGrid.Dock = DockStyle.Fill;
        _revenueGrid.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _revenueGrid.Location = new Point(3, 3);
        _revenueGrid.MultiSelect = false;
        _revenueGrid.Name = "_revenueGrid";
        _revenueGrid.ReadOnly = true;
        _revenueGrid.RowHeadersVisible = false;
        _revenueGrid.RowTemplate.Height = 25;
        _revenueGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _revenueGrid.Size = new Size(1086, 512);
        _revenueGrid.TabIndex = 0;
        // 
        // _topProductsTab
        // 
        _topProductsTab.Controls.Add(_topProductsGrid);
        _topProductsTab.Location = new Point(4, 26);
        _topProductsTab.Name = "_topProductsTab";
        _topProductsTab.Padding = new Padding(3);
        _topProductsTab.Size = new Size(1092, 518);
        _topProductsTab.TabIndex = 2;
        _topProductsTab.Text = "Món bán chạy";
        _topProductsTab.UseVisualStyleBackColor = true;
        // 
        // _topProductsGrid
        // 
        _topProductsGrid.AllowUserToAddRows = false;
        _topProductsGrid.AllowUserToDeleteRows = false;
        _topProductsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _topProductsGrid.BackgroundColor = SystemColors.Window;
        _topProductsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        _topProductsGrid.Dock = DockStyle.Fill;
        _topProductsGrid.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _topProductsGrid.Location = new Point(3, 3);
        _topProductsGrid.MultiSelect = false;
        _topProductsGrid.Name = "_topProductsGrid";
        _topProductsGrid.ReadOnly = true;
        _topProductsGrid.RowHeadersVisible = false;
        _topProductsGrid.RowTemplate.Height = 25;
        _topProductsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _topProductsGrid.Size = new Size(1086, 512);
        _topProductsGrid.TabIndex = 0;
        // 
        // ReportsForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1100, 700);
        Controls.Add(_tabs);
        Controls.Add(_cards);
        Controls.Add(_toolbar);
        MinimumSize = new Size(900, 600);
        Name = "ReportsForm";
        Text = "Thống kê và Dashboard";
        _toolbar.ResumeLayout(false);
        _cards.ResumeLayout(false);
        _tabs.ResumeLayout(false);
        _dashboardTab.ResumeLayout(false);
        _revenueTab.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_revenueGrid).EndInit();
        _topProductsTab.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_topProductsGrid).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private FlowLayoutPanel _toolbar;
    private Label _fromLabel;
    private DateTimePicker _from;
    private Label _toLabel;
    private DateTimePicker _to;
    private Button _statisticsButton;
    private Button _exportButton;
    private TableLayoutPanel _cards;
    private Label _todayRevenue;
    private Label _monthRevenue;
    private Label _yearRevenue;
    private Label _openTables;
    private TabControl _tabs;
    private TabPage _dashboardTab;
    private RevenueChart _chart;
    private TabPage _revenueTab;
    private DataGridView _revenueGrid;
    private TabPage _topProductsTab;
    private DataGridView _topProductsGrid;
}
