using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Forms;

public sealed class ProductManagementForm : Form
{
    private readonly DataGridView _grid = Ui.Grid();
    private readonly TextBox _search = Ui.TextBox(190);
    private readonly ComboBox _filterCategory = Ui.ComboBox(190);
    private readonly TextBox _name = Ui.TextBox();
    private readonly NumericUpDown _price = new() { Width = 220, Maximum = 100_000_000, Increment = 1000, ThousandsSeparator = true, Font = Ui.NormalFont };
    private readonly ComboBox _category = Ui.ComboBox();
    private readonly CheckBox _available = new() { Text = "Còn bán", Checked = true, AutoSize = true, Margin = new Padding(8) };
    private readonly TextBox _imagePath = Ui.TextBox();
    private readonly PictureBox _picture = new() { Width = 220, Height = 170, SizeMode = PictureBoxSizeMode.Zoom, BorderStyle = BorderStyle.FixedSingle };
    private int? _selectedId;

    public ProductManagementForm()
    {
        Text = "Quản lý đồ uống";

        var editor = new TableLayoutPanel
        {
            Dock = DockStyle.Right,
            Width = 420,
            Padding = new Padding(12),
            ColumnCount = 2,
            RowCount = 9,
            AutoScroll = true
        };
        editor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125));
        editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        AddRow(editor, 0, "Tên món", _name);
        AddRow(editor, 1, "Giá bán", _price);
        AddRow(editor, 2, "Danh mục", _category);
        editor.Controls.Add(_available, 1, 3);
        AddRow(editor, 4, "Đường dẫn ảnh", _imagePath);
        var chooseImage = Ui.Button("Chọn hình", (_, _) => ChooseImage(), 115);
        editor.Controls.Add(chooseImage, 0, 5);
        editor.Controls.Add(_picture, 1, 5);

        var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, WrapContents = true };
        buttons.Controls.AddRange([
            Ui.Button("Thêm", (_, _) => Add()),
            Ui.Button("Cập nhật", (_, _) => UpdateItem()),
            Ui.Button("Ngừng bán", (_, _) => ToggleAvailable()),
            Ui.Button("Xóa", (_, _) => Delete()),
            Ui.Button("Làm mới", (_, _) => ClearEditor())
        ]);
        editor.Controls.Add(buttons, 0, 7);
        editor.SetColumnSpan(buttons, 2);

        Controls.Add(_grid);
        Controls.Add(editor);
        Controls.Add(Ui.Row(
            Ui.Label("Tìm món", 70), _search,
            Ui.Label("Danh mục", 80), _filterCategory,
            Ui.Button("Lọc", (_, _) => LoadData()),
            Ui.Button("Tất cả", (_, _) => { _search.Clear(); _filterCategory.SelectedIndex = 0; LoadData(); })));

        _grid.CellClick += (_, _) => SelectRow();
        _imagePath.TextChanged += (_, _) => LoadPreview(_imagePath.Text);
        Load += (_, _) => { LoadCategories(); LoadData(); };
        FormClosed += (_, _) => _picture.Image?.Dispose();
    }

    private static void AddRow(TableLayoutPanel panel, int row, string label, Control control)
    {
        panel.Controls.Add(Ui.Label(label, 120), 0, row);
        panel.Controls.Add(control, 1, row);
    }

    private void LoadCategories()
    {
        using var db = new CafeDbContext();
        var categories = db.Categories.AsNoTracking().OrderBy(x => x.Name).Select(x => new { x.Id, x.Name }).ToList();
        _category.DisplayMember = "Name";
        _category.ValueMember = "Id";
        _category.DataSource = categories;

        var filter = new List<CategoryFilter> { new(0, "Tất cả danh mục") };
        filter.AddRange(categories.Select(x => new CategoryFilter(x.Id, x.Name)));
        _filterCategory.DisplayMember = nameof(CategoryFilter.Name);
        _filterCategory.ValueMember = nameof(CategoryFilter.Id);
        _filterCategory.DataSource = filter;
    }

    private void LoadData()
    {
        using var db = new CafeDbContext();
        string keyword = _search.Text.Trim();
        int categoryId = _filterCategory.SelectedValue is int id ? id : 0;
        _grid.DataSource = db.Products.AsNoTracking().Include(x => x.Category)
            .Where(x => (keyword == "" || x.Name.Contains(keyword)) && (categoryId == 0 || x.CategoryId == categoryId))
            .OrderBy(x => x.Name)
            .Select(x => new
            {
                x.Id,
                TenMon = x.Name,
                DanhMuc = x.Category != null ? x.Category.Name : "",
                GiaBan = x.Price,
                TrangThai = x.IsAvailable ? "Còn bán" : "Hết/Ngừng bán",
                HinhAnh = x.ImagePath
            }).ToList();
        if (_grid.Columns["Id"] is not null) _grid.Columns["Id"].Visible = false;
        if (_grid.Columns["GiaBan"] is not null) _grid.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
    }

    private bool ValidateInput()
    {
        if (_name.Text.Trim().Length < 2)
        {
            Ui.Error("Tên món phải có ít nhất 2 ký tự.");
            return false;
        }
        if (_price.Value <= 0)
        {
            Ui.Error("Giá bán phải lớn hơn 0.");
            return false;
        }
        if (_category.SelectedValue is not int)
        {
            Ui.Error("Vui lòng chọn danh mục.");
            return false;
        }
        return true;
    }

    private void Add()
    {
        if (!ValidateInput()) return;
        using var db = new CafeDbContext();
        if (db.Products.Any(x => x.Name == _name.Text.Trim()))
        {
            Ui.Error("Tên món đã tồn tại.");
            return;
        }
        db.Products.Add(new Product
        {
            Name = _name.Text.Trim(),
            Price = _price.Value,
            CategoryId = (int)_category.SelectedValue!,
            IsAvailable = _available.Checked,
            ImagePath = string.IsNullOrWhiteSpace(_imagePath.Text) ? null : _imagePath.Text.Trim()
        });
        db.SaveChanges();
        ClearEditor();
        LoadData();
    }

    private void UpdateItem()
    {
        if (_selectedId is null || !ValidateInput()) return;
        using var db = new CafeDbContext();
        if (db.Products.Any(x => x.Name == _name.Text.Trim() && x.Id != _selectedId.Value))
        {
            Ui.Error("Tên món đã tồn tại.");
            return;
        }
        var item = db.Products.Find(_selectedId.Value);
        if (item is null) return;
        item.Name = _name.Text.Trim();
        item.Price = _price.Value;
        item.CategoryId = (int)_category.SelectedValue!;
        item.IsAvailable = _available.Checked;
        item.ImagePath = string.IsNullOrWhiteSpace(_imagePath.Text) ? null : _imagePath.Text.Trim();
        db.SaveChanges();
        LoadData();
    }

    private void ToggleAvailable()
    {
        if (_selectedId is null) return;
        using var db = new CafeDbContext();
        var item = db.Products.Find(_selectedId.Value);
        if (item is null) return;
        item.IsAvailable = !item.IsAvailable;
        db.SaveChanges();
        _available.Checked = item.IsAvailable;
        LoadData();
    }

    private void Delete()
    {
        if (_selectedId is null || !Ui.Confirm("Xóa món đang chọn?")) return;
        using var db = new CafeDbContext();
        var item = db.Products.Include(x => x.InvoiceDetails).SingleOrDefault(x => x.Id == _selectedId.Value);
        if (item is null) return;
        if (item.InvoiceDetails.Count > 0)
        {
            item.IsAvailable = false;
            db.SaveChanges();
            Ui.Info("Món đã xuất hiện trong hóa đơn nên được chuyển sang ngừng bán thay vì xóa.");
        }
        else
        {
            db.Products.Remove(item);
            db.SaveChanges();
        }
        ClearEditor();
        LoadData();
    }

    private void SelectRow()
    {
        if (_grid.CurrentRow?.Cells["Id"].Value is not int id) return;
        using var db = new CafeDbContext();
        var item = db.Products.Find(id);
        if (item is null) return;
        _selectedId = id;
        _name.Text = item.Name;
        _price.Value = item.Price;
        _category.SelectedValue = item.CategoryId;
        _available.Checked = item.IsAvailable;
        _imagePath.Text = item.ImagePath ?? "";
    }

    private void ChooseImage()
    {
        using var dialog = new OpenFileDialog
        {
            Filter = "Hình ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tất cả file|*.*",
            Title = "Chọn hình món"
        };
        if (dialog.ShowDialog(this) == DialogResult.OK)
            _imagePath.Text = dialog.FileName;
    }

    private void LoadPreview(string path)
    {
        _picture.Image?.Dispose();
        _picture.Image = null;
        try
        {
            if (!File.Exists(path)) return;
            using var source = Image.FromFile(path);
            _picture.Image = new Bitmap(source);
        }
        catch
        {
            _picture.Image = null;
        }
    }

    private void ClearEditor()
    {
        _selectedId = null;
        _name.Clear();
        _price.Value = 0;
        if (_category.Items.Count > 0) _category.SelectedIndex = 0;
        _available.Checked = true;
        _imagePath.Clear();
        _grid.ClearSelection();
    }

    private sealed record CategoryFilter(int Id, string Name);
}
