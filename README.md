# CafeManager .NET 10 — bản sửa lỗi build

Bản này đã sửa lỗi biên dịch tại `SalesForm.cs` khi lấy giá trị từ `SelectionDialog<int>`, đổi tên các hàm `Update()` để không che khuất `Control.Update()`, và ghim SQLitePCLRaw 2.1.12.

# Cafe Manager - C# WinForms .NET 10

Đồ án quản lý quán café bằng **C# Windows Forms**, **.NET 10**, **Entity Framework Core 10** và **SQLite**.

## Tài khoản mẫu

| Quyền | Tài khoản | Mật khẩu |
|---|---|---|
| Admin | `admin` | `123456` |
| Nhân viên | `nhanvien` | `123456` |

Đổi mật khẩu ngay sau khi đăng nhập nếu dùng cho bản nộp chính thức.

## Cách chạy

1. Cài .NET 10 SDK và workload **.NET desktop development** trong Visual Studio.
2. Mở `CafeManager.slnx`. Nếu Visual Studio không nhận `.slnx`, mở trực tiếp `CafeManager.WinForms/CafeManager.WinForms.csproj`.
3. Chờ NuGet restore gói `Microsoft.EntityFrameworkCore.Sqlite`.
4. Nhấn `F5` để chạy.
5. Database `cafe_manager.db` tự tạo trong thư mục chạy chương trình.

Có thể chạy bằng Terminal trên Windows:

```bat
dotnet restore
dotnet run --project CafeManager.WinForms\CafeManager.WinForms.csproj
```

## Reset dữ liệu mẫu

Đóng chương trình, chạy `RESET_DATABASE.bat`, sau đó chạy lại ứng dụng. Database và dữ liệu mẫu sẽ được tạo lại.

## Chức năng

- Đăng nhập, băm mật khẩu PBKDF2, đổi/reset mật khẩu.
- CRUD tài khoản, phân quyền Admin/Nhân viên, khóa/mở khóa.
- Nhật ký đăng nhập và đăng xuất.
- CRUD và tìm kiếm nhân viên.
- CRUD/tìm kiếm danh mục.
- CRUD món, giá bán, còn/hết món, lọc danh mục, upload và hiển thị hình, validate.
- CRUD bàn và hiển thị trạng thái.
- Chọn bàn, thêm món, tăng/giảm số lượng, xóa món.
- Chuyển bàn, gộp hóa đơn, thanh toán, tích điểm, xem/in hóa đơn.
- CRUD/tìm kiếm khách hàng và lịch sử mua hàng.
- Doanh thu ngày/tháng/năm, món bán chạy, xuất Excel `.xls`, dashboard biểu đồ.

## Quy tắc nghiệp vụ

- `10.000đ = 1 điểm` khi thanh toán có chọn khách hàng.
- Bàn chuyển sang **Đang phục vụ** khi có món trong hóa đơn.
- Bàn trở về **Trống** sau thanh toán hoặc khi xóa hết món.
- Món đã xuất hiện trong hóa đơn không bị xóa vật lý; hệ thống chuyển thành **Ngừng bán**.
- Nhân viên/tài khoản có dữ liệu liên quan được bảo vệ khỏi việc xóa gây mất lịch sử.

## Cấu trúc

```text
CafeManager.WinForms/
├── Controls/       Biểu đồ dashboard tự vẽ
├── Data/           DbContext và khởi tạo database
├── Forms/          Các màn hình WinForms
├── Helpers/        UI, dialog, xuất Excel
├── Models/         Entity và enum
├── Security/       Băm/kiểm tra mật khẩu
├── Services/       Session và in hóa đơn
└── Program.cs
```

## Lưu ý

- Giao diện được tạo hoàn toàn bằng C#, không cần các file `.Designer.cs`. Điều này giúp project dễ copy, merge Git và tránh lỗi Designer.
- SQLite phù hợp để demo/nộp bài vì không cần cài SQL Server. Nếu giảng viên yêu cầu SQL Server, đổi provider trong `CafeDbContext` và chuỗi kết nối.
- Trước khi nộp, thay tên quán, dữ liệu mẫu, logo, màu giao diện và thông tin hóa đơn theo nhóm của bạn.
