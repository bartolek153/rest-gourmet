namespace WebAPI.Models
{
    public class TCAD_CARDAPIO_ITEM
    {
        public TCAD_CARDAPIO CARDAPIO { get; set; }
        public int CARDAPIOId { get; set; }
        public int ITEM { get; set; }
        public TCAD_RECEITA RECEITA { get; set; }
    }
}