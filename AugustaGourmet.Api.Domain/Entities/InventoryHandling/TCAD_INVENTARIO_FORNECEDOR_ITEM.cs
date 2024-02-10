using AugustaGourmet.Api.Domain.Entities.Companies;
using AugustaGourmet.Api.Domain.Entities.Products;
using AugustaGourmet.Api.Domain.Entities.Units;

namespace WebAPI.Models
{
    public class TCAD_INVENTARIO_FORNECEDOR_ITEM
    {
        public Int64 CODIGO_INVENTARIOId { get; set; }
        public int PRODUTOId { get; set; }
        public TCAD_INVENTARIO_FORNECEDOR CODIGO_INVENTARIO { get; set; }
        public Product PRODUTO { get; set; }
        public Company CODIGO_EMPRESA { get; set; }
        public TCAD_UNIDADE UNIDADE_ESTOQUE_MIN { get; set; }
        public decimal QUANTIDADE { get; set; }
        public decimal QUANTIDADE_CALCULADO { get; set; }
        public TCAD_UNIDADE UNIDADE_ESTOQUE_CAL { get; set; }
        public decimal QUANTIDADE_MINIMA { get; set; }
        public Decimal VALOR_TOTAL_ITEM { get; set; }
        public decimal PRECO_UNITARIO { get; set; }

        //Variável de controle para validar o que deve ser considerado no valor do pedido
        public int CONSISTIR_ITEM { get; set; }
    }
}