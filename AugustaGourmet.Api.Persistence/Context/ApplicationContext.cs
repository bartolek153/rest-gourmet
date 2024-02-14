﻿using System.Data.Entity;

using AugustaGourmet.Api.Domain.Common;
using AugustaGourmet.Api.Domain.Entities.Companies;
using AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Entities.Units;

namespace AugustaGourmet.Api.Persistence.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(string connectionString) : base(connectionString) { }

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

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InventoryParameter>()
            .Ignore(ip => ip.Id)
            .HasKey(ip => new { ip.CompanyId, ip.SupplierId, ip.InventoryProductId });

        // TODO: Create following indexes
        // - clustered unique:
        //   * InventoryParameter: CompanyId, SupplierId, InventoryProductId
        //
        // - Non-Unique
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