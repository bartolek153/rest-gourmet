namespace WebAPI.Models
{
    public class TCAD_PREPARO_ITEM_PASSOS
    {
        public Int64 Id { get; set; }
        public TCAD_PREPARO_PRODUTO_ITEM PREPARO_ITEM { get; set; }
        public int SEQUENCIA { get; set; }
        public String DESCRICAO { get; set; }
    }
}