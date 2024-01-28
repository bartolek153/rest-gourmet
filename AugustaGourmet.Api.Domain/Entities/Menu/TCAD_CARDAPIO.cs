using AugustaGourmet.Api.Domain.Entities.Company;
using AugustaGourmet.Api.Domain.Entities.Others;

namespace WebAPI.Models
{
    public class TCAD_CARDAPIO
    {
        public int Id { get; set; }
        public TCAD_EMPRESA CODIGO_EMPRESA { get; set; }
        public TCAD_SEMANA SEMANA { get; set; }
        public TCAD_DIA_SEMANA DIA_SEMANA { get; set; }
    }
}