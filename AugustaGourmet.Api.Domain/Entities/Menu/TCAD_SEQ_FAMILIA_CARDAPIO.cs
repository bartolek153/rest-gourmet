using AugustaGourmet.Api.Domain.Entities.Products;

namespace WebAPI.Models
{
    public class TCAD_SEQ_FAMILIA_CARDAPIO
    {
        public int Id { get; set; }
        public ProductGroup GRUPO_PRODUTO { get; set; }
        public int SEQUENCIA { get; set; }
    }
}