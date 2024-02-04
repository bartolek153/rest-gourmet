using System.Data.Entity;

using AugustaGourmet.Api.Domain.Common;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;
using AugustaGourmet.Api.Domain.Entities.Invoicing;
using AugustaGourmet.Api.Domain.Entities.Products;

namespace AugustaGourmet.Api.Persistence.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(string connectionString) : base(connectionString) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductGroup> ProductGroups { get; set; }
    public DbSet<ProductFamily> ProductFamilies { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<PartnerProduct> PartnerProducts { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
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