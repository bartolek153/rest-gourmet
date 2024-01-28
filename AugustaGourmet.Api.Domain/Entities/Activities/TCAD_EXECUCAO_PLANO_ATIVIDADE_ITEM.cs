namespace WebAPI.Models
{
    public class TCAD_EXECUCAO_PLANO_ATIVIDADE_ITEM
    {
        public TCAD_EXECUCAO_PLANO_ATIVIDADE PLANO_EXECUCAO { get; set; }
        public Int64 PLANO_EXECUCAO_Id { get; set; }
        public TCAD_PLANO_ATIVIDADE_ITEM PLANO_ITEM { get; set; }
        public int PLANO_ATIVIDADEId { get; set; }
        public int ITEM { get; set; }
        public String PARAMENTRO_ENTRADA { get; set; }
    }
}