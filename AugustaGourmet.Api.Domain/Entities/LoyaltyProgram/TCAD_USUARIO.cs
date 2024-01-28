namespace WebAPI.Models
{
    public class TCAD_USUARIO
    {
        public Int64 Id { get; set; }
        public String NOME { get; set; }
        public string EMAIL { get; set; }
        public string PSW { get; set; }
        public DateTime? DATA_NASCIMENTO { get; set; }
        public string CELULAR { get; set; }
        public string CPF { get; set; }
        public int PONTUACAO { get; set; }
        public string TOKEN_FCM { get; set; }
        public int PONTUACAO_MAXIMA { get; set; } = 1;
        public DateTime? DATA_PRIMEIRA_PONTUACAO { get; set; }
        [NotMapped]
        public List<TCAD_USUARIO_VOUCHER> ListaVoucher { get; set; }
        [NotMapped]
        public List<TCAD_USUARIO_VOUCHER> ListaVoucherPendente { get; set; }
        [NotMapped]
        public bool PODE_PONTUAR { get; set; }
        [NotMapped]
        public bool PODE_RESGATAR { get; set; }
        [NotMapped]
        public int VALOR_PONTUACAO { get; set; }
    }
}