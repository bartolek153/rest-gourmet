using AugustaGourmet.Api.Domain.Entities.Company;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Entities.Units;
using AugustaGourmet.Api.Domain.Enums;

namespace WebAPI.Models
{
    public class TCAD_RECEITA
    {
        public int Id { get; set; }
        public TCAD_EMPRESA EMPRESA { get; set; }
        public Product PRODUTO { get; set; }
        public TCAD_UNIDADE UNIDADE { get; set; }
        public Int32 QUANTIDADE { get; set; }
        public Int32 TEMPO_PREPARO { get; set; }
        public TCAD_STATUS_GERAL STATUS { get; set; }
    }
}