using AugustaGourmet.Api.Domain.Entities.Companies;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;
using AugustaGourmet.Api.Domain.Entities.Others;

namespace WebAPI.Models
{
    public class TCAD_INVENTARIO_FORNECEDOR
    {
        public Int64 Id { get; set; }
        public Company CODIGO_EMPRESA { get; set; }
        public Supplier CODIGO_FORNECEDOR { get; set; }
        public DateTime DATA_INVENTARIO { get; set; }
        public TCAD_STATUS_INVENTARIO STATUS { get; set; }
        public int PEDIDO_ENVIADO { get; set; }
        public Int32 QUANTIDADE_ITENS { get; set; }
        public decimal VALOR_TOTAL_ITENS { get; set; }
        public DateTime? DATA_REALIZADO { get; set; }
        public TCAD_FUNCIONARIO FUNCIONARIO { get; set; }
        public TCAD_DIA_SEMANA DIA_SEMANA { get; set; }
    }
}