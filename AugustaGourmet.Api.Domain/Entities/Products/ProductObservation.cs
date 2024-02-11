using AugustaGourmet.Api.Domain.Entities.Companies;

namespace AugustaGourmet.Api.Domain.Entities.Products;

public class TCAD_OBSERVACAO_PRODUTO
{
    public long Id { get; set; }
    public ProductGroup GRUPO_PRODUTO { get; set; }
    public string OBSERVACAO { get; set; }
    public Company EMPRESA { get; set; }
    public Product PRODUTO { get; set; }
}