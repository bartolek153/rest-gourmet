using AugustaGourmet.Api.Domain.Entities.Units;

namespace AugustaGourmet.Api.Domain.Entities.Products;

public class TCAD_ESTRUTURA_PRODUTO
{
    public Product PRODUTO_PAI { get; set; }
    public int CODIGO_PRODUTO_PAI { get; set; }
    public Product PRODUTO_FILHO { get; set; }
    public int CODIGO_PRODUTO_FILHO { get; set; }
    public decimal QUANTIDADE { get; set; }
    public UnitMeasure UNIDADE_PRODUTO { get; set; }
}