using AugustaGourmet.Api.Domain.Entities.Products;

namespace AugustaGourmet.Api.Domain.Entities.Units;

public class TCAD_UNIDADE_PRODUTO
{
    public int CODIGO_PRODUTO { get; set; }
    public int CODIGO_UNIDADE { get; set; }

    public Product PRODUTO { get; set; }
    public TCAD_UNIDADE UNIDADE { get; set; }
}