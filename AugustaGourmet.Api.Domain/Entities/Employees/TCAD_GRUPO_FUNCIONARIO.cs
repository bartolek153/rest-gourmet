using AugustaGourmet.Api.Domain.Entities.Companies;

namespace WebAPI.Models
{
    public class TCAD_GRUPO_FUNCIONARIO
    {
        public int Id { get; set; }
        public Company CODIGO_EMPRESA { get; set; }
        public string DESCRICAO { get; set; }
    }
}