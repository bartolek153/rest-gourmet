namespace WebAPI.Models
{
    public class TPRO_SOLIC_OBSERVACAO
    {
        public Int64 SOLICITACAOId { get; set; }
        public TPRO_SOLICITACAO_IMPRESSAO SOLICITACAO { get; set; }
        public int ITEM { get; set; }
        public string OBSERVACAO { get; set; }
    }
}