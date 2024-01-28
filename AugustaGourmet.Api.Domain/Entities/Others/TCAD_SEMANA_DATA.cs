namespace AugustaGourmet.Api.Domain.Entities.Others
{
    public class TCAD_SEMANA_DATA
    {
        public long Id { get; set; }
        public TCAD_SEMANA SEMANA { get; set; }
        public DateTime DATA { get; set; }
        public TCAD_DIA_SEMANA DIA_SEMANA { get; set; }
    }
}