using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Forms;

public sealed class CategoryManagementForm : Form
{
    private readonly DataGridView _grid = Ui.Grid();
    private readonly TextBox _search = Ui.TextBox();
    private readonly TextBox _name = Ui.TextBox();
    private readonly TextBox _description = new() { Width = 220, Height = 90, Multiline = true, Font = Ui.NormalFont };
    private int? _selectedId;

    public CategoryManagementForm()
    {
        Text = "Quản lý danh mục";
        var editor = new TableLayoutPanel { Dock = DockStyle.Right, Width = 390, Padding = new Padding(15), ColumnCount = 2, RowCount = 4 };
        editor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
        editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        editor.Controls.Add(Ui.Label("Tên danh mục", 115), 0, 0);
        editor.Controls.Add(_name, 1, 0);
        editor.Controls.Add(Ui.Label("Mô tả", 115), 0, 1);
        editor.Controls.Add(_description, 1, 1);
        var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoSize = true, WrapContents = true };
        buttons.Controls.AddRange([
            Ui.Button("Thêm", (_, _) => Add()),
            Ui.Button("Cập nhật", (_, _) => UpdateItem()),
            Ui.Button("Xóa", (_, _) => Delete()),
            Ui.Button("Làm mới", (_, _) => ClearEditor())
        ]);
        editor.Controls.Add(buttons, 0, 2);
        editor.SetColumnSpan(buttons, 2);

        Controls.Add(_grid);
        Controls.Add(editor);
        Controls.Add(Ui.Row(Ui.Label("Tìm danh mục", 115), _search,
            Ui.Button("Tìm", (_, _) => LoadData()),
            Ui.Button("Tất cả", (_, _) => { _search.Clear(); LoadData(); })));
        _grid.CellClick += (_, _) => SelectRow();
        Load += (_, _) => LoadData();
    }

    private void LoadData()
    {
        using var db = new CafeDbContext();
        string keyword = _search.Text.Trim();
        _grid.DataSource = db.Categories.AsNoTracking()
            .Where(x => keyword == "" || x.Name.Contains(keyword))
            .OrderBy(x => x.Name)
            .Select(x => new { x.Id, TenDanhMuc = x.Name, MoTa = x.Description, SoMon = x.Products.Count }).ToList();
        if (_grid.Columns["Id"] is not null) _grid.Columns["Id"].Visible = false;
    }

    private bool ValidateInput()
    {
        if (_name.Text.Trim().Length < 2)
        {
            Ui.Error("Tên danh mục phải có ít nhất 2 ký tự.");
            return false;
        }
        return true;
    }

    private void Add()
    {
        if (!ValidateInput()) return;
        using var db = new CafeDbContext();
        if (db.Categories.Any(x => x.Name == _name.Text.Trim()))
        {
            Ui.Error("Danh mục đã tồn tại.");
            return;
        }
        db.Categories.Add(new Category { Name = _name.Text.Trim(), Description = _description.Text.Trim() });
        db.SaveChanges();
        ClearEditor();
        LoadData();
    }

    private void UpdateItem()
    {
        if (_selectedId is null || !ValidateInput()) return;
        using var db = new CafeDbContext();
        if (db.Categories.Any(x => x.Name == _name.Text.Trim() && x.Id != _selectedId.Value))
        {
            Ui.Error("Tên danh mục đã tồn tại.");
            return;
        }
        var item = db.Categories.Find(_selectedId.Value);
        if (item is null) return;
        item.Name = _name.Text.Trim();
        item.Description = _description.Text.Trim();
        db.SaveChanges();
        LoadData();
    }

    private void Delete()
    {
        if (_selectedId is null || !Ui.Confirm("Xóa danh mục đang chọn?")) return;
        using var db = new CafeDbContext();
        var item = db.Categories.Include(x => x.Products).SingleOrDefault(x => x.Id == _selectedId.Value);
        if (item is null) return;
        if (item.Products.Count > 0)
        {
            Ui.Error("Danh mục đang có món, không thể xóa.");
            return;
        }
        db.Categories.Remove(item);
        db.SaveChanges();
        ClearEditor();
        LoadData();
    }

    private void SelectRow()
    {
        if (_grid.CurrentRow?.Cells["Id"].Value is not int id) return;
        using var db = new CafeDbContext();
        var item = db.Categories.Find(id);
        if (item is null) return;
        _selectedId = id;
        _name.Text = item.Name;
        _description.Text = item.Description;
    }

    private void ClearEditor()
    {
        _selectedId = null;
        _name.Clear();
        _description.Clear();
        _grid.ClearSelection();
    }
}
