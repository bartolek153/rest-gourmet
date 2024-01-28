using AugustaGourmet.Api.Domain.Entities.Company;

namespace AugustaGourmet.Api.Domain.Entities.Others
{
    public class TCAD_LOCAL
    {
        public int Id { get; set; }
        public TCAD_EMPRESA CODIGO_EMPRESA { get; set; }
        public string DESCRICAO { get; set; }
    }
}