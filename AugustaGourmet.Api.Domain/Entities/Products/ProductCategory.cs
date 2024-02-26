using AugustaGourmet.Api.Domain.Entities.Companies;

namespace AugustaGourmet.Api.Domain.Entities.Products;

[Table("TCAD_CATEGORIA_PRODUTO")]
public class ProductCategory : BaseEntity
{
    [Column("EMPRESA_Id")]
    public int? CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public Company Company { get; set; } = null!;

    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;

    [Column("IMPRESSORA_Id")]
    public int? PrinterId { get; set; }

    public int EXIBIR_CARDAPIO { get; set; }  // TODO: check use
}