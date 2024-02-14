using AugustaGourmet.Api.Domain.Entities.Companies;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Entities.Units;

namespace AugustaGourmet.Api.Domain.Entities.InventoryHandling;

[Table("TCAD_BASE_INVENTARIO")]
public class InventoryParameter : BaseEntity
{
    [Column("CODIGO_EMPRESAId")]
    public int CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public Company Company { get; set; } = null!;

    [Column("CODIGO_FORNECEDORId")]
    public int SupplierId { get; set; }
    [ForeignKey("SupplierId")]
    public Supplier Supplier { get; set; } = null!;

    [Column("CODIGO_PRODUTOId")]
    public int InventoryProductId { get; set; }
    [ForeignKey("InventoryProductId")]
    public Product InventoryProduct { get; set; } = null!;

    [Column("ESTOQUE_MINIMO")]
    public decimal MinStockQuantity { get; set; }
    [Column("UNIDADE_EST_MINIMO_Id")]
    public int MinStockUnitId { get; set; }
    [ForeignKey("MinStockUnitId")]
    public UnitMeasure MinStockUnit { get; set; } = null!;

    [Column("ESTOQUE_MAXIMO")]
    public decimal MaxStockQuantity { get; set; }
    [Column("UNIDADE_EST_MAXIMO_Id")]
    public int MaxStockUnitId { get; set; }
    [ForeignKey("MaxStockUnitId")]
    public UnitMeasure MaxStockUnit { get; set; } = null!;

    [Column("CONTAGEM_OBRIGATORIA")]  //TODO: change to bool
    public int CountIsMandatory { get; set; }

    [Column("CODIGO_PRODUTO_FORNECEDOR")]
    public string? SupplierProductId { get; set; } = null!;

    [NotMapped]
    public decimal? Quantity { get; set; }
}