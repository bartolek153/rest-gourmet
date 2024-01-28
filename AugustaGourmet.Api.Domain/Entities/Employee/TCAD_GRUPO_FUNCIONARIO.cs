using AugustaGourmet.Api.Domain.Entities.Company;

namespace WebAPI.Models
{
    public class TCAD_GRUPO_FUNCIONARIO
    {
        public int Id { get; set; }
        public TCAD_EMPRESA CODIGO_EMPRESA { get; set; }
        public string DESCRICAO { get; set; }
    }
}