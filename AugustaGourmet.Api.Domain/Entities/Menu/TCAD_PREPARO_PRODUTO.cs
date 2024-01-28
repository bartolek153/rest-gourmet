using AugustaGourmet.Api.Domain.Entities.Company;

namespace WebAPI.Models
{
    public class TCAD_PREPARO_PRODUTO
    {
        public Int32 Id { get; set; }
        public TCAD_RECEITA RECEITA { get; set; }
        public TCAD_EMPRESA EMPRESA { get; set; }
        public string DESCRICAO { get; set; }
    }
}