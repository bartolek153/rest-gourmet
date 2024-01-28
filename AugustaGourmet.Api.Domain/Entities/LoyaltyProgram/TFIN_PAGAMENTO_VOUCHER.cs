namespace WebAPI.Models
{
    public class TFIN_PAGAMENTO_VOUCHER
    {
        public Int64 Id { get; set; }
        public DateTime DATA_RESGATE { get; set; }
        public Decimal VALOR_TOTAL { get; set; }
        public TCAD_USUARIO USUARIO { get; set; }
        public TFIN_STATUS_PAG_VOUCHER STATUS { get; set; }
        public DateTime? DATA_UTILIZACAO { get; set; }
        public decimal VALOR_UTILIZADO { get; set; }
    }
}