using AugustaGourmet.Api.Domain.Entities.InventoryHandling;

namespace WebAPI.Models
{
    public class TCAD_NOTA_FISCAL_CAPA
    {
        public int Id { get; set; }

        public TCAD_FORNECEDOR Fornecedor { get; set; }
        public int NotaFiscal { get; set; }
        public int Serie { get; set; }
        public DateTime DataEmissao { get; set; }
        public string CnpjEmitente { get; set; }
        public double ValorOriginal { get; set; }
        public double ValorLiquido { get; set; }
        public string Chave { get; set; }
    }
}