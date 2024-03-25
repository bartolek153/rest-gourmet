using AugustaGourmet.Api.Domain.Common;
using AugustaGourmet.Api.Domain.Entities.Alerts;
using AugustaGourmet.Api.Domain.Entities.Companies;
using AugustaGourmet.Api.Domain.Entities.Employees;
using AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Entities.Units;
using AugustaGourmet.Api.Domain.Entities.Users;

using Microsoft.EntityFrameworkCore;

namespace AugustaGourmet.Api.Persistence.Context;

public sealed class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<Company> Companies { get; set; }
    public DbSet<InventoryParameter> InventoryParameters { get; set; }
    public DbSet<PartnerProduct> PartnerProducts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductFamily> ProductFamilies { get; set; }
    public DbSet<ProductGroup> ProductGroups { get; set; }
    public DbSet<ProductOrigin> ProductOrigins { get; set; }
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<ReceiptLine> ReceiptLines { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<UnitMeasure> UnitMeasures { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }
    public DbSet<EmployeeIncidentLog> EmployeeIncidentLogs { get; set; }
    public DbSet<AlertType> AlertTypes { get; set; }
    public DbSet<EmployeeAlert> EmployeeAlerts { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InventoryParameter>(builder =>
        {
            builder
                .Ignore(ip => ip.Id)
                .HasKey(ip => new { ip.CompanyId, ip.SupplierId, ip.InventoryProductId });
        });

        modelBuilder.Entity<User>().Property(u => u.Id).HasConversion<long>();

        // TODO: Create indexes
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseAuditableEntity>()
            .Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified))
        {
            entry.Entity.LastModified = DateTime.Now;

            if (entry.State == EntityState.Added)
                entry.Entity.Created = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}