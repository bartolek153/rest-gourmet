namespace WebAPI.Models
{
    public class TCAD_CONTROLE_FUNCIONARIO
    {
        public Int64 Id { get; set; }
        public TCAD_FUNCIONARIO FUNCIONARIO { get; set; }
        public DateTime DATA_APONTAMENTO { get; set; }
        public DateTime DATA_ENTRADA { get; set; }
        public DateTime? DATA_SAIDA { get; set; }
        public double ATRASO { get; set; }
        public TCAD_STATUS_APT_FUNCIONARIO STATUS { get; set; }
        public TCAD_TIPO_ATRASO TIPO_ATRASO { get; set; }
        public double EXTRA { get; set; }
        public string DESCRICAO_ABONO { get; set; }
    }
}