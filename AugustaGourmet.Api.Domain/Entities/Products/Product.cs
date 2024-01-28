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

    [Column("PROCEDENCIA_Id")]
    public int OriginId { get; set; }

    [Column("UNIDADE_PRODUTO_Id")]
    public int ProductUnitId { get; set; }

    [Column("UNIDADE_COMPRA_Id")]
    public int PurchaseUnitId { get; set; }

    [Column("PRECO_COMPRA")]
    public decimal PurchasePrice { get; set; }

    [Column("STATUS_Id")]
    public int StatusId { get; set; }
}