namespace WebAPI.Models
{
    public class TSOL_RESET_SENHA_USER
    {
        public Int64 Id { get; set; }
        public TCAD_USUARIO USUARIO { get; set; }
        public DateTime DATA_SOLICITACAO { get; set; }
        public DateTime DATA_VALIDADE { get; set; }
        public string TOKEN_SOLICITACAO { get; set; }
        public TSOL_STATUS_RESET_SENHA STATUS { get; set; }
    }
}