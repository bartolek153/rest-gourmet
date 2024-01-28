using AugustaGourmet.Api.Domain.Entities.Products;

namespace WebAPI.Models
{
    public class TPRO_SOLICITACAO_IMPRESSAO
    {
        public Int64 Id { get; set; }
        public Product PRODUTO { get; set; }
        public TPRO_STATUS_SOLIC_IMPRESSAO STATUS { get; set; }
        public DateTime DATA_SOLICITACAO { get; set; }
        public string OBSERVACAO_ERRO { get; set; }
        [NotMapped]
        public List<TPRO_SOLIC_OBSERVACAO> LISTA_OBSERVACOES { get; set; }

    }
}