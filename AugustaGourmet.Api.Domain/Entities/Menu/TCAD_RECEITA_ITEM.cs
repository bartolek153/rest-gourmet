using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Entities.Units;

namespace WebAPI.Models
{
    public class TCAD_RECEITA_ITEM
    {
        public TCAD_RECEITA RECEITA { get; set; }
        public int RECEITAId { get; set; }
        public Int32 ITEM { get; set; }
        public string DESCRICAO { get; set; }
        public Product PRODUTO_INGREDIENTE { get; set; }
        public Int32 QUANTIDADE_INGREDIENTE { get; set; }
        public UnitMeasure UNIDADE_INGREDIENTE { get; set; }
    }
}