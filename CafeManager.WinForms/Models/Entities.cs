using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeManager.WinForms.Models;

public enum AccountRole
{
    Admin = 1,
    Employee = 2
}

public enum TableStatus
{
    Empty = 1,
    Serving = 2,
    Reserved = 3
}

public enum InvoiceStatus
{
    Open = 1,
    Paid = 2,
    Cancelled = 3
}

public sealed class Employee
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;

    [MaxLength(10)]
    public string Gender { get; set; } = "Nam";

    public DateTime BirthDate { get; set; } = DateTime.Today.AddYears(-20);

    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    [MaxLength(250)]
    public string Address { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Position { get; set; } = "Nhân viên";

    public DateTime HireDate { get; set; } = DateTime.Today;

    public Account? Account { get; set; }
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}

public sealed class Account
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [MaxLength(500)]
    public string PasswordHash { get; set; } = string.Empty;

    public AccountRole Role { get; set; } = AccountRole.Employee;
    public bool IsActive { get; set; } = true;

    public int? EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public ICollection<LoginLog> LoginLogs { get; set; } = new List<LoginLog>();
}

public sealed class LoginLog
{
    public int Id { get; set; }
    public int? AccountId { get; set; }
    public Account? Account { get; set; }
    public DateTime LoginAt { get; set; } = DateTime.Now;
    public DateTime? LogoutAt { get; set; }
    public bool Success { get; set; }

    [MaxLength(250)]
    public string Note { get; set; } = string.Empty;
}

public sealed class Category
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(250)]
    public string Description { get; set; } = string.Empty;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}

public sealed class Product
{
    public int Id { get; set; }

    [MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [MaxLength(500)]
    public string? ImagePath { get; set; }

    public bool IsAvailable { get; set; } = true;

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}

public sealed class CafeTable
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public TableStatus Status { get; set; } = TableStatus.Empty;
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}

public sealed class Customer
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;

    [MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    [MaxLength(250)]
    public string Address { get; set; } = string.Empty;

    public int Points { get; set; }
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}

public sealed class Invoice
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? PaidAt { get; set; }
    public InvoiceStatus Status { get; set; } = InvoiceStatus.Open;

    public int TableId { get; set; }
    public CafeTable? Table { get; set; }

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Subtotal { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Discount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }

    public ICollection<InvoiceDetail> Details { get; set; } = new List<InvoiceDetail>();
}

public sealed class InvoiceDetail
{
    public int Id { get; set; }
    public int InvoiceId { get; set; }
    public Invoice? Invoice { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }

    [NotMapped]
    public decimal Amount => Quantity * UnitPrice;
}
