using CafeManager.WinForms.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeManager.WinForms.Data;

public sealed class CafeDbContext : DbContext
{
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<LoginLog> LoginLogs => Set<LoginLog>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<CafeTable> CafeTables => Set<CafeTable>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceDetail> InvoiceDetails => Set<InvoiceDetail>();

    public static string DatabasePath => Path.Combine(AppContext.BaseDirectory, "cafe_manager.db");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DatabasePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasIndex(x => x.Username).IsUnique();
        modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<CafeTable>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Customer>().HasIndex(x => x.Phone);

        modelBuilder.Entity<Employee>()
            .HasOne(x => x.Account)
            .WithOne(x => x.Employee)
            .HasForeignKey<Account>(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Invoice>()
            .HasOne(x => x.Table)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.TableId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Invoice>()
            .HasOne(x => x.Employee)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<InvoiceDetail>()
            .HasOne(x => x.Product)
            .WithMany(x => x.InvoiceDetails)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
