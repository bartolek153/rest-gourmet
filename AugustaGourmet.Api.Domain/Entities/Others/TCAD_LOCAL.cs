using AugustaGourmet.Api.Domain.Entities.Companies;

namespace AugustaGourmet.Api.Domain.Entities.Others
{
    public class TCAD_LOCAL
    {
        public int Id { get; set; }
        public Companies.Company CODIGO_EMPRESA { get; set; }
        public string DESCRICAO { get; set; }
    }
}