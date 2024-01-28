using AugustaGourmet.Api.Domain.Entities.Products;

namespace WebAPI.Models
{
    public class TCAD_CARDAPIO_DIARIO_ITEM
    {
        public TCAD_CARDAPIO_DIARIO CARDAPIO { get; set; }
        public Int64 CARDAPIOId { get; set; }
        public int ITEM { get; set; }
        public Product PRODUTO { get; set; }
    }
}