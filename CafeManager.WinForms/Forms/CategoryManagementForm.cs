using CafeManager.WinForms.Data;
using CafeManager.WinForms.Helpers;
using CafeManager.WinForms.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Forms;

public sealed partial class CategoryManagementForm : Form
{
    private int? _selectedId;

    public CategoryManagementForm()
    {
        InitializeComponent();
        Ui.WireButton(this, "Thêm", (_, _) => Add());
        Ui.WireButton(this, "Cập nhật", (_, _) => UpdateItem());
        Ui.WireButton(this, "Xóa", (_, _) => Delete());
        Ui.WireButton(this, "Làm mới", (_, _) => ClearEditor());
        Ui.WireButton(this, "Tìm", (_, _) => LoadData());
        Ui.WireButton(this, "Tất cả", (_, _) => { _search.Clear(); LoadData(); });
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
