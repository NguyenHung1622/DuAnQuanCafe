using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Models;
using CafeManager.WinForms.Services;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Forms;

public sealed class SalesForm : Form
{
    private readonly FlowLayoutPanel _tablesPanel = new()
    {
        Dock = DockStyle.Fill,
        AutoScroll = true,
        WrapContents = true,
        Padding = new Padding(8)
    };
    private readonly DataGridView _productsGrid = Ui.Grid();
    private readonly DataGridView _detailsGrid = Ui.Grid();
    private readonly TextBox _productSearch = Ui.TextBox(150);
    private readonly ComboBox _categoryFilter = Ui.ComboBox(150);
    private readonly ComboBox _customer = Ui.ComboBox(220);
    private readonly NumericUpDown _discount = new() { Width = 150, Maximum = 100_000_000, Increment = 1000, ThousandsSeparator = true, Font = Ui.NormalFont };
    private readonly Label _selectedTableLabel = new() { Text = "Chưa chọn bàn", Dock = DockStyle.Top, Height = 42, Font = new Font("Segoe UI Semibold", 15F), TextAlign = ContentAlignment.MiddleCenter };
    private readonly Label _subtotalLabel = new() { Text = "Tạm tính: 0 đ", AutoSize = true, Font = new Font("Segoe UI Semibold", 11F), Margin = new Padding(8) };
    private readonly Label _totalLabel = new() { Text = "Tổng: 0 đ", AutoSize = true, Font = new Font("Segoe UI Semibold", 13F), Margin = new Padding(8) };
    private int? _selectedTableId;
    private int? _currentInvoiceId;
    private int? _lastPaidInvoiceId;

    public SalesForm()
    {
        Text = "Bán hàng";
        var main = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, RowCount = 1 };
        main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24));
        main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36));
        main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));

        var tableGroup = new GroupBox { Text = "Danh sách bàn", Dock = DockStyle.Fill, Font = Ui.NormalFont };
        tableGroup.Controls.Add(_tablesPanel);

        var productGroup = new GroupBox { Text = "Danh sách món", Dock = DockStyle.Fill, Font = Ui.NormalFont };
        productGroup.Controls.Add(_productsGrid);
        productGroup.Controls.Add(Ui.Row(_productSearch, _categoryFilter,
            Ui.Button("Lọc", (_, _) => LoadProducts(), 75),
            Ui.Button("Thêm món", (_, _) => AddSelectedProduct(), 105)));

        var invoiceGroup = new GroupBox { Text = "Hóa đơn", Dock = DockStyle.Fill, Font = Ui.NormalFont };
        var invoiceBottom = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom,
            Height = 180,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = true,
            Padding = new Padding(5)
        };
        invoiceBottom.Controls.AddRange([
            Ui.Button("+ Số lượng", (_, _) => ChangeQuantity(1), 110),
            Ui.Button("- Số lượng", (_, _) => ChangeQuantity(-1), 110),
            Ui.Button("Xóa món", (_, _) => RemoveDetail(), 100),
            Ui.Button("Chuyển bàn", (_, _) => TransferTable(), 110),
            Ui.Button("Gộp HĐ", (_, _) => MergeInvoice(), 100),
            Ui.Label("Khách hàng", 95), _customer,
            Ui.Label("Giảm giá", 80), _discount,
            Ui.Button("Áp dụng", (_, _) => RefreshTotals(), 90),
            _subtotalLabel, _totalLabel,
            Ui.Button("Thanh toán", (_, _) => Pay(), 120),
            Ui.Button("In hóa đơn", (_, _) => PrintInvoice(), 120)
        ]);
        invoiceGroup.Controls.Add(_detailsGrid);
        invoiceGroup.Controls.Add(invoiceBottom);
        invoiceGroup.Controls.Add(_selectedTableLabel);

        main.Controls.Add(tableGroup, 0, 0);
        main.Controls.Add(productGroup, 1, 0);
        main.Controls.Add(invoiceGroup, 2, 0);
        Controls.Add(main);

        _productsGrid.CellDoubleClick += (_, _) => AddSelectedProduct();
        _discount.ValueChanged += (_, _) => RefreshTotals();
        Load += (_, _) =>
        {
            LoadCategoryFilter();
            LoadCustomers();
            RefreshTables();
            LoadProducts();
        };
    }

    private void LoadCategoryFilter()
    {
        using var db = new CafeDbContext();
        var data = new List<CategoryChoice> { new(0, "Tất cả") };
        data.AddRange(db.Categories.AsNoTracking().OrderBy(x => x.Name).Select(x => new CategoryChoice(x.Id, x.Name)));
        _categoryFilter.DisplayMember = nameof(CategoryChoice.Name);
        _categoryFilter.ValueMember = nameof(CategoryChoice.Id);
        _categoryFilter.DataSource = data;
    }

    private void LoadCustomers()
    {
        using var db = new CafeDbContext();
        var data = new List<CustomerChoice> { new(null, "Không chọn / Khách lẻ") };
        data.AddRange(db.Customers.AsNoTracking().OrderBy(x => x.FullName).Select(x => new CustomerChoice(x.Id, $"{x.FullName} - {x.Phone}")));
        _customer.DisplayMember = nameof(CustomerChoice.Name);
        _customer.ValueMember = nameof(CustomerChoice.Id);
        _customer.DataSource = data;
    }

    private void RefreshTables()
    {
        int? keepSelected = _selectedTableId;
        _tablesPanel.SuspendLayout();
        _tablesPanel.Controls.Clear();
        using var db = new CafeDbContext();
        var tables = db.CafeTables.AsNoTracking().OrderBy(x => x.Name).ToList();
        foreach (var table in tables)
        {
            string status = table.Status switch
            {
                TableStatus.Empty => "Trống",
                TableStatus.Serving => "Đang phục vụ",
                _ => "Đã đặt"
            };
            var button = new Button
            {
                Text = $"{table.Name}\n{status}",
                Tag = table.Id,
                Width = 118,
                Height = 70,
                Margin = new Padding(6),
                Font = Ui.NormalFont,
                BackColor = table.Status switch
                {
                    TableStatus.Empty => Color.Honeydew,
                    TableStatus.Serving => Color.MistyRose,
                    _ => Color.LemonChiffon
                },
                FlatStyle = FlatStyle.Flat
            };
            button.Click += (_, _) => SelectTable((int)button.Tag);
            _tablesPanel.Controls.Add(button);
        }
        _tablesPanel.ResumeLayout();
        if (keepSelected is not null && tables.Any(x => x.Id == keepSelected))
            SelectTable(keepSelected.Value);
    }

    private void LoadProducts()
    {
        using var db = new CafeDbContext();
        string keyword = _productSearch.Text.Trim();
        int categoryId = _categoryFilter.SelectedValue is int id ? id : 0;
        _productsGrid.DataSource = db.Products.AsNoTracking().Include(x => x.Category)
            .Where(x => x.IsAvailable && (keyword == "" || x.Name.Contains(keyword)) && (categoryId == 0 || x.CategoryId == categoryId))
            .OrderBy(x => x.Name)
            .Select(x => new { x.Id, TenMon = x.Name, DanhMuc = x.Category != null ? x.Category.Name : "", GiaBan = x.Price }).ToList();
        if (_productsGrid.Columns["Id"] is not null) _productsGrid.Columns["Id"].Visible = false;
        if (_productsGrid.Columns["GiaBan"] is not null) _productsGrid.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
    }

    private void SelectTable(int tableId)
    {
        _selectedTableId = tableId;
        using var db = new CafeDbContext();
        var table = db.CafeTables.AsNoTracking().Single(x => x.Id == tableId);
        _selectedTableLabel.Text = table.Name;
        var invoice = db.Invoices.AsNoTracking().SingleOrDefault(x => x.TableId == tableId && x.Status == InvoiceStatus.Open);
        _currentInvoiceId = invoice?.Id;
        _discount.Value = invoice is null ? 0 : Math.Min(invoice.Discount, _discount.Maximum);
        if (invoice?.CustomerId is int customerId)
            _customer.SelectedValue = customerId;
        else
            _customer.SelectedIndex = 0;
        LoadDetails();
    }

    private void LoadDetails()
    {
        if (_currentInvoiceId is null)
        {
            _detailsGrid.DataSource = null;
            _subtotalLabel.Text = "Tạm tính: 0 đ";
            _totalLabel.Text = "Tổng: 0 đ";
            return;
        }

        using var db = new CafeDbContext();
        _detailsGrid.DataSource = db.InvoiceDetails.AsNoTracking().Include(x => x.Product)
            .Where(x => x.InvoiceId == _currentInvoiceId.Value)
            .OrderBy(x => x.Id)
            .Select(x => new
            {
                x.Id,
                TenMon = x.Product != null ? x.Product.Name : "",
                SoLuong = x.Quantity,
                DonGia = x.UnitPrice,
                ThanhTien = x.Quantity * x.UnitPrice
            }).ToList();
        if (_detailsGrid.Columns["Id"] is not null) _detailsGrid.Columns["Id"].Visible = false;
        if (_detailsGrid.Columns["DonGia"] is not null) _detailsGrid.Columns["DonGia"].DefaultCellStyle.Format = "N0";
        if (_detailsGrid.Columns["ThanhTien"] is not null) _detailsGrid.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        RefreshTotals();
    }

    private void AddSelectedProduct()
    {
        if (_selectedTableId is null)
        {
            Ui.Error("Vui lòng chọn bàn trước.");
            return;
        }
        if (_productsGrid.CurrentRow?.Cells["Id"].Value is not int productId)
        {
            Ui.Error("Vui lòng chọn món.");
            return;
        }

        using var db = new CafeDbContext();
        var product = db.Products.SingleOrDefault(x => x.Id == productId && x.IsAvailable);
        if (product is null) return;
        var invoice = db.Invoices.Include(x => x.Details)
            .SingleOrDefault(x => x.TableId == _selectedTableId.Value && x.Status == InvoiceStatus.Open);
        if (invoice is null)
        {
            invoice = new Invoice
            {
                TableId = _selectedTableId.Value,
                EmployeeId = AppSession.EmployeeId,
                CreatedAt = DateTime.Now,
                Status = InvoiceStatus.Open
            };
            db.Invoices.Add(invoice);
        }

        var detail = invoice.Details.SingleOrDefault(x => x.ProductId == productId);
        if (detail is null)
            invoice.Details.Add(new InvoiceDetail { ProductId = productId, Quantity = 1, UnitPrice = product.Price });
        else
            detail.Quantity++;

        var table = db.CafeTables.Find(_selectedTableId.Value)!;
        table.Status = TableStatus.Serving;
        Recalculate(invoice);
        db.SaveChanges();
        _currentInvoiceId = invoice.Id;
        LoadDetails();
        RefreshTableButtonsOnly();
    }

    private void ChangeQuantity(int delta)
    {
        if (_detailsGrid.CurrentRow?.Cells["Id"].Value is not int detailId) return;
        using var db = new CafeDbContext();
        var detail = db.InvoiceDetails.Include(x => x.Invoice).SingleOrDefault(x => x.Id == detailId);
        if (detail?.Invoice is null) return;
        detail.Quantity += delta;
        if (detail.Quantity <= 0) db.InvoiceDetails.Remove(detail);
        db.SaveChanges();
        RecalculateInvoiceInDatabase(detail.InvoiceId);
        LoadDetails();
    }

    private void RemoveDetail()
    {
        if (_detailsGrid.CurrentRow?.Cells["Id"].Value is not int detailId || !Ui.Confirm("Xóa món khỏi hóa đơn?")) return;
        using var db = new CafeDbContext();
        var detail = db.InvoiceDetails.Find(detailId);
        if (detail is null) return;
        int invoiceId = detail.InvoiceId;
        db.InvoiceDetails.Remove(detail);
        db.SaveChanges();
        RecalculateInvoiceInDatabase(invoiceId);
        LoadDetails();
    }

    private void RecalculateInvoiceInDatabase(int invoiceId)
    {
        using var db = new CafeDbContext();
        var invoice = db.Invoices.Include(x => x.Details).SingleOrDefault(x => x.Id == invoiceId);
        if (invoice is null) return;

        if (invoice.Details.Count == 0)
        {
            var table = db.CafeTables.Find(invoice.TableId);
            if (table is not null) table.Status = TableStatus.Empty;
            db.Invoices.Remove(invoice);
            db.SaveChanges();
            if (_currentInvoiceId == invoiceId) _currentInvoiceId = null;
            _discount.Value = 0;
            RefreshTableButtonsOnly();
            return;
        }

        Recalculate(invoice);
        db.SaveChanges();
    }

    private static void Recalculate(Invoice invoice)
    {
        invoice.Subtotal = invoice.Details.Sum(x => x.Quantity * x.UnitPrice);
        invoice.Discount = Math.Clamp(invoice.Discount, 0, invoice.Subtotal);
        invoice.Total = invoice.Subtotal - invoice.Discount;
    }

    private void RefreshTotals()
    {
        if (_currentInvoiceId is null)
        {
            _subtotalLabel.Text = "Tạm tính: 0 đ";
            _totalLabel.Text = "Tổng: 0 đ";
            return;
        }
        using var db = new CafeDbContext();
        var invoice = db.Invoices.Include(x => x.Details).SingleOrDefault(x => x.Id == _currentInvoiceId.Value);
        if (invoice is null) return;
        decimal subtotal = invoice.Details.Sum(x => x.Quantity * x.UnitPrice);
        decimal discount = Math.Min(_discount.Value, subtotal);
        _subtotalLabel.Text = "Tạm tính: " + Ui.Money(subtotal);
        _totalLabel.Text = "Tổng: " + Ui.Money(subtotal - discount);
    }

    private void TransferTable()
    {
        if (_selectedTableId is null || _currentInvoiceId is null)
        {
            Ui.Error("Bàn hiện tại chưa có hóa đơn.");
            return;
        }
        using var db = new CafeDbContext();
        var choices = db.CafeTables.AsNoTracking()
            .Where(x => x.Id != _selectedTableId && x.Status != TableStatus.Serving)
            .OrderBy(x => x.Name)
            .Select(x => new SelectionItem<int> { Text = x.Name, Value = x.Id }).ToList();
        if (choices.Count == 0)
        {
            Ui.Error("Không có bàn trống để chuyển.");
            return;
        }
        using var dialog = new SelectionDialog<int>("Chuyển bàn", "Chọn bàn đích", choices);
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        int targetId = dialog.SelectedValue;

        var invoice = db.Invoices.Single(x => x.Id == _currentInvoiceId.Value);
        var source = db.CafeTables.Single(x => x.Id == _selectedTableId.Value);
        var target = db.CafeTables.Single(x => x.Id == targetId);
        invoice.TableId = targetId;
        source.Status = TableStatus.Empty;
        target.Status = TableStatus.Serving;
        db.SaveChanges();
        _selectedTableId = targetId;
        RefreshTables();
        Ui.Info("Chuyển bàn thành công.");
    }

    private void MergeInvoice()
    {
        if (_selectedTableId is null || _currentInvoiceId is null)
        {
            Ui.Error("Bàn hiện tại chưa có hóa đơn để gộp.");
            return;
        }
        using var db = new CafeDbContext();
        var choices = db.CafeTables.AsNoTracking()
            .Where(x => x.Id != _selectedTableId && x.Status == TableStatus.Serving && x.Invoices.Any(i => i.Status == InvoiceStatus.Open))
            .OrderBy(x => x.Name)
            .Select(x => new SelectionItem<int> { Text = x.Name, Value = x.Id }).ToList();
        if (choices.Count == 0)
        {
            Ui.Error("Không có hóa đơn bàn khác để gộp.");
            return;
        }
        using var dialog = new SelectionDialog<int>("Gộp hóa đơn", "Gộp vào bàn", choices);
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        int targetTableId = dialog.SelectedValue;
        if (!Ui.Confirm("Gộp toàn bộ món của bàn hiện tại vào bàn đã chọn?")) return;

        var sourceInvoice = db.Invoices.Include(x => x.Details).Single(x => x.Id == _currentInvoiceId.Value);
        var targetInvoice = db.Invoices.Include(x => x.Details).Single(x => x.TableId == targetTableId && x.Status == InvoiceStatus.Open);
        foreach (var sourceDetail in sourceInvoice.Details.ToList())
        {
            var targetDetail = targetInvoice.Details.SingleOrDefault(x => x.ProductId == sourceDetail.ProductId && x.UnitPrice == sourceDetail.UnitPrice);
            if (targetDetail is null)
                targetInvoice.Details.Add(new InvoiceDetail { ProductId = sourceDetail.ProductId, Quantity = sourceDetail.Quantity, UnitPrice = sourceDetail.UnitPrice });
            else
                targetDetail.Quantity += sourceDetail.Quantity;
        }
        Recalculate(targetInvoice);
        var sourceTable = db.CafeTables.Single(x => x.Id == _selectedTableId.Value);
        sourceTable.Status = TableStatus.Empty;
        db.Invoices.Remove(sourceInvoice);
        db.SaveChanges();
        _selectedTableId = targetTableId;
        RefreshTables();
        Ui.Info("Gộp hóa đơn thành công.");
    }

    private void Pay()
    {
        if (_currentInvoiceId is null || _selectedTableId is null)
        {
            Ui.Error("Bàn chưa có hóa đơn.");
            return;
        }
        using var db = new CafeDbContext();
        var invoice = db.Invoices.Include(x => x.Details).SingleOrDefault(x => x.Id == _currentInvoiceId.Value);
        if (invoice is null || invoice.Details.Count == 0)
        {
            Ui.Error("Hóa đơn chưa có món.");
            return;
        }

        Recalculate(invoice);
        invoice.Discount = Math.Min(_discount.Value, invoice.Subtotal);
        invoice.Total = invoice.Subtotal - invoice.Discount;
        invoice.CustomerId = _customer.SelectedValue is int customerId ? customerId : null;
        string message = $"Tổng thanh toán: {Ui.Money(invoice.Total)}\nXác nhận thanh toán?";
        if (!Ui.Confirm(message)) return;

        invoice.Status = InvoiceStatus.Paid;
        invoice.PaidAt = DateTime.Now;
        var table = db.CafeTables.Find(_selectedTableId.Value)!;
        table.Status = TableStatus.Empty;
        if (invoice.CustomerId is int id)
        {
            var customer = db.Customers.Find(id);
            if (customer is not null) customer.Points += (int)Math.Floor(invoice.Total / 10_000m);
        }
        db.SaveChanges();
        _lastPaidInvoiceId = invoice.Id;
        _currentInvoiceId = null;
        _discount.Value = 0;
        _customer.SelectedIndex = 0;
        LoadDetails();
        RefreshTableButtonsOnly();
        Ui.Info("Thanh toán thành công. Điểm khách hàng được cộng theo quy tắc 10.000đ = 1 điểm.");
        if (Ui.Confirm("Bạn có muốn xem/in hóa đơn ngay không?")) InvoicePrinter.Preview(this, invoice.Id);
    }

    private void PrintInvoice()
    {
        int? invoiceId = _currentInvoiceId ?? _lastPaidInvoiceId;
        if (invoiceId is null)
        {
            Ui.Error("Chưa có hóa đơn để in.");
            return;
        }
        InvoicePrinter.Preview(this, invoiceId.Value);
    }

    private void RefreshTableButtonsOnly()
    {
        int? selected = _selectedTableId;
        RefreshTables();
        if (selected is not null) SelectTable(selected.Value);
    }

    private sealed record CategoryChoice(int Id, string Name);
    private sealed record CustomerChoice(int? Id, string Name);
}
