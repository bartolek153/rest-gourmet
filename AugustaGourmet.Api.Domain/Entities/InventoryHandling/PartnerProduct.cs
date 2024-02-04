
using AugustaGourmet.Api.Domain.Entities.Products;

namespace AugustaGourmet.Api.Domain.Entities.InventoryHandling;

public class PartnerProduct : BaseEntity
{
    [ForeignKey("PartnerId")]
    public Supplier Partner { get; set; } = null!;
    [Column("Supplier_Id")]
    public int PartnerId { get; set; }

    [Column("SupplierProductId")]
    public string PartnerProductId { get; set; } = string.Empty;

    [Column("SupplierProductDescription")]
    public string PartnerProductDescription { get; set; } = string.Empty;

    [Column("Product_Id")]
    public int? InventoryProductId { get; set; }
    [ForeignKey("InventoryProductId")]
    public Product? InventoryProduct { get; set; }
}