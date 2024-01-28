namespace WebAPI.Models
{
    public class TCAD_USUARIO_VOUCHER
    {
        public Int64 Id { get; set; }
        public DateTime DATA_VALIDADE { get; set; }
        public TCAD_USUARIO USUARIO { get; set; }
        public decimal VALOR { get; set; }
        public DateTime DATA_CRIACAO { get; set; }
        public TCAD_STATUS_VOUCHER STATUS { get; set; }
        public DateTime? DATA_UTILIZACAO { get; set; }
        public Decimal VALOR_UTILIZADO { get; set; }
        public Decimal VALOR_EMPENHADO { get; set; }
    }
}