using AugustaGourmet.Api.Domain.Entities.Companies;

namespace WebAPI.Models
{
    public class TCAD_ATIVIDADE
    {
        public int Id { get; set; }
        public Company CODIGO_EMPRESA { get; set; }
        public string DESCRICAO { get; set; }
    }
}