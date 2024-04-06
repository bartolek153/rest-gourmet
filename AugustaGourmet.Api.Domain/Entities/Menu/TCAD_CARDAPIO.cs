using AugustaGourmet.Api.Domain.Entities.Companies;
using AugustaGourmet.Api.Domain.Entities.General;

namespace WebAPI.Models
{
    public class TCAD_CARDAPIO
    {
        public int Id { get; set; }
        public Company CODIGO_EMPRESA { get; set; }
        public TCAD_SEMANA SEMANA { get; set; }
        public TCAD_DIA_SEMANA DIA_SEMANA { get; set; }
    }
}