namespace AugustaGourmet.Api.Domain.Entities.Products;

[Table("TCAD_PROCEDENCIA_PRODUTO")]
public class ProductOrigin : BaseEntity
{
    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;
}