namespace WebAPI.Models
{
    public class TCAD_PREPARO_ITEM_RECEITA
    {
        public int CODIGO_PREPARO { get; set; }
        public int ITEM_PREPARO { get; set; }
        public TCAD_PREPARO_PRODUTO_ITEM PREPARO_ITEM { get; set; }

        public int CODIGO_RECEITA { get; set; }
        public int ITEM_RECEITA { get; set; }
        public TCAD_RECEITA_ITEM RECEITA_ITEM { get; set; }
    }
}