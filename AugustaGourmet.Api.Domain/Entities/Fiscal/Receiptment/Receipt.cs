
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;

namespace AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;

[Table("TCAD_NOTA_FISCAL_CAPA")]
public class Receipt : BaseEntity
{
    [Column("Fornecedor_Id")]
    public int SupplierId { get; set; }
    [ForeignKey("SupplierId")]
    public Supplier Supplier { get; set; } = null!;

    [Column("DataEmissao")]
    public DateTime IssueDate { get; set; }

    [Column("CnpjEmitente")]
    public string IssuerCnpj { get; set; } = string.Empty;

    [Column("ValorOriginal")]
    public double TotalAmount { get; set; }

    [Column("ValorLiquido")]
    public double NetAmount { get; set; }

    [Column("NotaFiscal")]
    public int DocumentNumber { get; set; }
    [Column("Serie")]
    public int Serie { get; set; }
    [Column("Chave")]
    public string NfeId { get; set; } = string.Empty;

    public ICollection<ReceiptLine> Lines { get; set; }
}