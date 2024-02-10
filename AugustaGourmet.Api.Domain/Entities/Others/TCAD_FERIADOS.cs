using AugustaGourmet.Api.Domain.Entities.Companies;

namespace AugustaGourmet.Api.Domain.Entities.Others
{
    public class TCAD_FERIADOS
    {
        public int Id { get; set; }
        public Companies.Company CODIGO_EMPRESA { get; set; }
        public string DESCRICAO { get; set; }
        public DateTime DATA { get; set; }
    }
}