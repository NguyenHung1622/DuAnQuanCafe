#nullable disable

namespace CafeManager.WinForms.Forms;

partial class EmployeeManagementForm
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
        _fullNameLabel = new Label();
        _fullName = new TextBox();
        _genderLabel = new Label();
        _gender = new ComboBox();
        _birthDateLabel = new Label();
        _birthDate = new DateTimePicker();
        _phoneLabel = new Label();
        _phone = new TextBox();
        _addressLabel = new Label();
        _address = new TextBox();
        _positionLabel = new Label();
        _position = new TextBox();
        _hireDateLabel = new Label();
        _hireDate = new DateTimePicker();
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
        _searchLabel.Size = new Size(115, 32);
        _searchLabel.Text = "Tìm nhân viên";
        _searchLabel.TextAlign = ContentAlignment.MiddleLeft;
        _search.Size = new Size(210, 31);
        _searchButton.AutoSize = true;
        _searchButton.Text = "Tìm";
        _allButton.AutoSize = true;
        _allButton.Text = "Tất cả";

        _editor.ColumnCount = 2;
        _editor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        _editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _editor.Controls.Add(_fullNameLabel, 0, 0);
        _editor.Controls.Add(_fullName, 1, 0);
        _editor.Controls.Add(_genderLabel, 0, 1);
        _editor.Controls.Add(_gender, 1, 1);
        _editor.Controls.Add(_birthDateLabel, 0, 2);
        _editor.Controls.Add(_birthDate, 1, 2);
        _editor.Controls.Add(_phoneLabel, 0, 3);
        _editor.Controls.Add(_phone, 1, 3);
        _editor.Controls.Add(_addressLabel, 0, 4);
        _editor.Controls.Add(_address, 1, 4);
        _editor.Controls.Add(_positionLabel, 0, 5);
        _editor.Controls.Add(_position, 1, 5);
        _editor.Controls.Add(_hireDateLabel, 0, 6);
        _editor.Controls.Add(_hireDate, 1, 6);
        _editor.Controls.Add(_buttons, 0, 7);
        _editor.Dock = DockStyle.Right;
        _editor.Padding = new Padding(12);
        _editor.RowCount = 9;
        _editor.SetColumnSpan(_buttons, 2);
        _editor.Width = 385;
        _fullNameLabel.Text = "Họ tên";
        _fullNameLabel.Dock = DockStyle.Fill;
        _genderLabel.Text = "Giới tính";
        _genderLabel.Dock = DockStyle.Fill;
        _birthDateLabel.Text = "Ngày sinh";
        _birthDateLabel.Dock = DockStyle.Fill;
        _phoneLabel.Text = "Điện thoại";
        _phoneLabel.Dock = DockStyle.Fill;
        _addressLabel.Text = "Địa chỉ";
        _addressLabel.Dock = DockStyle.Fill;
        _positionLabel.Text = "Chức vụ";
        _positionLabel.Dock = DockStyle.Fill;
        _hireDateLabel.Text = "Ngày vào làm";
        _hireDateLabel.Dock = DockStyle.Fill;
        _fullName.Dock = DockStyle.Fill;
        _gender.Dock = DockStyle.Fill;
        _gender.DropDownStyle = ComboBoxStyle.DropDownList;
        _birthDate.Dock = DockStyle.Fill;
        _birthDate.Format = DateTimePickerFormat.Short;
        _phone.Dock = DockStyle.Fill;
        _address.Dock = DockStyle.Fill;
        _position.Dock = DockStyle.Fill;
        _hireDate.Dock = DockStyle.Fill;
        _hireDate.Format = DateTimePickerFormat.Short;

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
        ClientSize = new Size(1100, 700);
        Controls.Add(_grid);
        Controls.Add(_editor);
        Controls.Add(_toolbar);
        Font = new Font("Segoe UI", 10F);
        Name = "EmployeeManagementForm";
        Text = "Quản lý nhân viên";
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
    private Label _fullNameLabel;
    private TextBox _fullName;
    private Label _genderLabel;
    private ComboBox _gender;
    private Label _birthDateLabel;
    private DateTimePicker _birthDate;
    private Label _phoneLabel;
    private TextBox _phone;
    private Label _addressLabel;
    private TextBox _address;
    private Label _positionLabel;
    private TextBox _position;
    private Label _hireDateLabel;
    private DateTimePicker _hireDate;
    private FlowLayoutPanel _buttons;
    private Button _addButton;
    private Button _updateButton;
    private Button _deleteButton;
    private Button _clearButton;
}
