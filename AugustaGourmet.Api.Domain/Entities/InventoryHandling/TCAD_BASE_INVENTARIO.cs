using AugustaGourmet.Api.Domain.Entities.Company;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Entities.Units;

namespace WebAPI.Models
{
    public class TCAD_BASE_INVENTARIO
    {
        public TCAD_FORNECEDOR CODIGO_FORNECEDOR { get; set; }
        public int CODIGO_FORNECEDORId { get; set; }
        public Product CODIGO_PRODUTO { get; set; }
        public int CODIGO_PRODUTOId { get; set; }
        public decimal ESTOQUE_MINIMO { get; set; }
        public decimal ESTOQUE_MAXIMO { get; set; }
        public TCAD_UNIDADE UNIDADE_EST_MINIMO { get; set; }
        public TCAD_UNIDADE UNIDADE_EST_MAXIMO { get; set; }
        public TCAD_EMPRESA CODIGO_EMPRESA { get; set; }
        public int CODIGO_EMPRESAId { get; set; }
        public int CONTAGEM_OBRIGATORIA { get; set; }
        [NotMapped]
        public decimal? Quantidade { get; set; }

        public string CODIGO_PRODUTO_FORNECEDOR { get; set; }
    }
}