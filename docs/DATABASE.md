# Thiết kế cơ sở dữ liệu

```mermaid
erDiagram
    EMPLOYEE ||--o| ACCOUNT : has
    ACCOUNT ||--o{ LOGIN_LOG : writes
    CATEGORY ||--o{ PRODUCT : contains
    CAFE_TABLE ||--o{ INVOICE : receives
    EMPLOYEE ||--o{ INVOICE : creates
    CUSTOMER ||--o{ INVOICE : owns
    INVOICE ||--|{ INVOICE_DETAIL : contains
    PRODUCT ||--o{ INVOICE_DETAIL : appears
```

## Bảng chính

- `Employees`: nhân viên.
- `Accounts`: tài khoản, vai trò, trạng thái khóa.
- `LoginLogs`: lịch sử đăng nhập/đăng xuất.
- `Categories`: danh mục món.
- `Products`: món, giá, hình, trạng thái bán.
- `CafeTables`: bàn và trạng thái.
- `Customers`: khách hàng và điểm.
- `Invoices`: hóa đơn mở/đã thanh toán.
- `InvoiceDetails`: món, số lượng và đơn giá tại thời điểm bán.

Database SQLite được tạo bằng `Database.EnsureCreated()` khi chương trình chạy lần đầu.
