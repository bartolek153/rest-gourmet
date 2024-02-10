using AugustaGourmet.Api.Domain.Entities.Companies;

namespace AugustaGourmet.Api.Domain.Entities.Products;

[Table("TCAD_FAMILIA_PRODUTO")]
public class ProductFamily : BaseEntity
{
    [Column("EMPRESA_Id")]
    public int? CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public Companies.Company Company { get; set; } = null!;

    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;

    [Column("CATEGORIA_Id")]
    public int? CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public ProductCategory Category { get; set; } = null!;
}