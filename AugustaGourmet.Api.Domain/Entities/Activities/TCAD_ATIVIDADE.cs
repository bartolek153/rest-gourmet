using AugustaGourmet.Api.Domain.Entities.Company;

namespace WebAPI.Models
{
    public class TCAD_ATIVIDADE
    {
        public int Id { get; set; }
        public TCAD_EMPRESA CODIGO_EMPRESA { get; set; }
        public string DESCRICAO { get; set; }
    }
}