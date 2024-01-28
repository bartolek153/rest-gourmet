namespace WebAPI.Models
{
    public class TFIN_PAGAMENTO_VOUCHER_ITEM
    {
        public TFIN_PAGAMENTO_VOUCHER PAGAMENTO { get; set; }
        public Int64 PAGAMENTOId { get; set; }
        public TCAD_USUARIO_VOUCHER VOUCHER_USER { get; set; }
        public Int64 VOUCHER_USERId { get; set; }
        public decimal VALOR_SALDO { get; set; }
    }
}