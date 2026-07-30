using CafeManager.WinForms.Models;
using CafeManager.WinForms.Security;

namespace CafeManager.WinForms.Data;

public static class DatabaseInitializer
{
    public static void Initialize()
    {
        using var db = new CafeDbContext();
        db.Database.EnsureCreated();

        if (!db.Employees.Any())
        {
            var adminEmployee = new Employee
            {
                FullName = "Quản trị viên",
                Gender = "Nam",
                Phone = "0900000001",
                Address = "Hệ thống",
                Position = "Quản lý",
                HireDate = DateTime.Today
            };
            var employee = new Employee
            {
                FullName = "Nhân viên mẫu",
                Gender = "Nữ",
                Phone = "0900000002",
                Address = "TP. Hồ Chí Minh",
                Position = "Thu ngân",
                HireDate = DateTime.Today
            };
            db.Employees.AddRange(adminEmployee, employee);
            db.SaveChanges();

            db.Accounts.AddRange(
                new Account
                {
                    Username = "admin",
                    PasswordHash = PasswordHasher.Hash("123456"),
                    Role = AccountRole.Admin,
                    IsActive = true,
                    EmployeeId = adminEmployee.Id
                },
                new Account
                {
                    Username = "nhanvien",
                    PasswordHash = PasswordHasher.Hash("123456"),
                    Role = AccountRole.Employee,
                    IsActive = true,
                    EmployeeId = employee.Id
                });
        }

        if (!db.Categories.Any())
        {
            var coffee = new Category { Name = "Cà phê", Description = "Các loại cà phê" };
            var tea = new Category { Name = "Trà", Description = "Trà và trà trái cây" };
            var other = new Category { Name = "Khác", Description = "Nước uống khác" };
            db.Categories.AddRange(coffee, tea, other);
            db.SaveChanges();

            db.Products.AddRange(
                new Product { Name = "Cà phê đen", Price = 25000, CategoryId = coffee.Id },
                new Product { Name = "Cà phê sữa", Price = 30000, CategoryId = coffee.Id },
                new Product { Name = "Bạc xỉu", Price = 35000, CategoryId = coffee.Id },
                new Product { Name = "Trà đào", Price = 40000, CategoryId = tea.Id },
                new Product { Name = "Trà chanh", Price = 30000, CategoryId = tea.Id },
                new Product { Name = "Nước suối", Price = 15000, CategoryId = other.Id });
        }

        if (!db.CafeTables.Any())
        {
            for (int i = 1; i <= 12; i++)
                db.CafeTables.Add(new CafeTable { Name = $"Bàn {i:00}", Status = TableStatus.Empty });
        }

        if (!db.Customers.Any())
        {
            db.Customers.AddRange(
                new Customer { FullName = "Khách lẻ", Phone = "", Address = "", Points = 0 },
                new Customer { FullName = "Nguyễn Văn A", Phone = "0912345678", Address = "TP. Hồ Chí Minh", Points = 25 });
        }

        db.SaveChanges();
    }
}
