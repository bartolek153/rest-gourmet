namespace WebAPI.Models
{
    public class TCAD_EXECUCAO_PLANO_ATIVIDADE
    {
        public Int64 Id { get; set; }
        public TCAD_PLANO_ATIVIDADE PLANO_ATIVIDADE { get; set; }
        public TCAD_STATUS_PLANO_ATIVIDADES STATUS { get; set; }
        public DateTime DATA_CRIACAO { get; set; }
        public DateTime? DATA_FINALIZACAO { get; set; }
        public TCAD_FUNCIONARIO FUNCIONARIO { get; set; }
        public DateTime DATA_EXECUCAO { get; set; }
        public DateTime DATA_EXECUCAO_INICIAL { get; set; }
        [NotMapped]
        public List<TCAD_PLANO_ATIVIDADE_ITEM> ITENS_ATIVIDADE { get; set; }
    }
}