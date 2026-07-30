# Ma trận 40 task

| Task | Chức năng | Vị trí chính |
|---:|---|---|
| 1 | Giao diện đăng nhập | `Forms/LoginForm.cs` |
| 2 | Xác thực tài khoản | `LoginForm`, `PasswordHasher` |
| 3 | Đổi mật khẩu | `ChangePasswordForm` |
| 4 | Quên/reset mật khẩu | `AccountManagementForm.ResetPassword` |
| 5 | CRUD tài khoản | `AccountManagementForm` |
| 6 | Admin/Nhân viên | `AccountRole`, `MainForm` |
| 7 | Khóa/mở khóa | `AccountManagementForm.ToggleActive` |
| 8 | Nhật ký đăng nhập | `LoginLog`, `LoginLogForm` |
| 9 | CRUD nhân viên | `EmployeeManagementForm` |
| 10 | Tìm kiếm nhân viên | `EmployeeManagementForm.LoadData` |
| 11 | CRUD danh mục | `CategoryManagementForm` |
| 12 | Tìm kiếm danh mục | `CategoryManagementForm.LoadData` |
| 13 | CRUD món | `ProductManagementForm` |
| 14 | Upload hình món | `ProductManagementForm.ChooseImage` |
| 15 | Quản lý giá bán | `Product.Price`, `NumericUpDown` |
| 16 | Còn/hết món | `Product.IsAvailable` |
| 17 | Tìm kiếm món | `ProductManagementForm.LoadData` |
| 18 | Lọc danh mục | `ProductManagementForm` và `SalesForm` |
| 19 | Hiển thị hình | `PictureBox` trong `ProductManagementForm` |
| 20 | Validate dữ liệu | Các hàm `ValidateInput` |
| 21 | CRUD bàn | `TableManagementForm` |
| 22 | Trạng thái bàn | `CafeTable.Status`, màu danh sách bàn |
| 23 | Chuyển bàn | `SalesForm.TransferTable` |
| 24 | Chọn bàn | `SalesForm.SelectTable` |
| 25 | Thêm món | `SalesForm.AddSelectedProduct` |
| 26 | Cập nhật số lượng | `SalesForm.ChangeQuantity` |
| 27 | Xóa món | `SalesForm.RemoveDetail` |
| 28 | Gộp hóa đơn | `SalesForm.MergeInvoice` |
| 29 | Thanh toán | `SalesForm.Pay` |
| 30 | In hóa đơn | `InvoicePrinter` |
| 31 | CRUD khách hàng | `CustomerManagementForm` |
| 32 | Tìm kiếm khách hàng | `CustomerManagementForm.LoadData` |
| 33 | Tích điểm | `SalesForm.Pay`, `AddPoints` |
| 34 | Lịch sử mua hàng | `CustomerManagementForm.LoadHistory` |
| 35 | Doanh thu ngày | `ReportsForm` |
| 36 | Doanh thu tháng | `ReportsForm` |
| 37 | Doanh thu năm | `ReportsForm` |
| 38 | Món bán chạy | `ReportsForm` |
| 39 | Xuất Excel | `ExcelXmlExporter` |
| 40 | Dashboard biểu đồ | `RevenueChart`, `ReportsForm` |
