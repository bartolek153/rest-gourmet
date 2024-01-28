using AugustaGourmet.Api.Domain.Entities.Company;

namespace AugustaGourmet.Api.Domain.Entities.Others
{
    public class TCAD_FERIADOS
    {
        public int Id { get; set; }
        public TCAD_EMPRESA CODIGO_EMPRESA { get; set; }
        public string DESCRICAO { get; set; }
        public DateTime DATA { get; set; }
    }
}