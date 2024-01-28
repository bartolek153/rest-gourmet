using AugustaGourmet.Api.Domain.Entities.Products;

namespace WebAPI.Models
{
    public class TCAD_NOTA_FISCAL_LINHA
    {
        public int Id { get; set; }
        public TCAD_NOTA_FISCAL_CAPA Capa { get; set; }

        public string CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public Product Produto { get; set; }

        public string UnidadeCompra { get; set; }
        public double QuantidadeCompra { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTotal { get; set; }

        // impostos
        public double ValorICMS { get; set; }
        public double ValorIPI { get; set; }
        public double AliquotaICMS { get; set; }
        public double AliquotaIPI { get; set; }
    }
}