using AugustaGourmet.Api.Domain.Entities.Units;

namespace AugustaGourmet.Api.Domain.Entities.Products;

[Table("TCAD_PRODUTO")]
public class Product : BaseEntity
{
    [Column("EMPRESA_Id")]
    public int CompanyId { get; set; }

    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;

    [Column("GRUPO_PRODUTO_Id")]
    public int GroupId { get; set; }
    [ForeignKey("GroupId")]
    public ProductGroup Group { get; set; } = null!;

    [Column("PROCEDENCIA_Id")]
    public int OriginId { get; set; }
    [ForeignKey("OriginId")]
    public ProductOrigin Origin { get; set; } = null!;

    [Column("UNIDADE_PRODUTO_Id")]
    public int ProductUnitId { get; set; }
    [ForeignKey("ProductUnitId")]
    public BaseUnit ProductUnit { get; set; } = null!;

    [Column("UNIDADE_COMPRA_Id")]
    public int PurchaseUnitId { get; set; }
    [ForeignKey("PurchaseUnitId")]
    public UnitMeasure PurchaseUnit { get; set; } = null!;

    [Column("PRECO_COMPRA")]
    public decimal PurchasePrice { get; set; }

    [Column("STATUS_Id")]
    public int StatusId { get; set; }
    [ForeignKey("StatusId")]
    public ProductStatus Status { get; set; } = null!;
}