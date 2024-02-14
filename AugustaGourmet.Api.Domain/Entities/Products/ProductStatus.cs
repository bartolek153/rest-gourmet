namespace AugustaGourmet.Api.Domain.Entities.Products;

[Table("TCAD_STATUS_PRODUTO")]
public class ProductStatus : BaseEntity
{
    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;
}