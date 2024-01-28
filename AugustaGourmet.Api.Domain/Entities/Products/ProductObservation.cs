using AugustaGourmet.Api.Domain.Entities.Company;

namespace AugustaGourmet.Api.Domain.Entities.Products;

public class TCAD_OBSERVACAO_PRODUTO
{
    public long Id { get; set; }
    public ProductGroup GRUPO_PRODUTO { get; set; }
    public string OBSERVACAO { get; set; }
    public TCAD_EMPRESA EMPRESA { get; set; }
    public Product PRODUTO { get; set; }
}