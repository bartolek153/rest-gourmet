
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

    public int DocumentNumber { get; set; }
    public int Serie { get; set; }
    public string NfeId { get; set; } = string.Empty;

    // invoice lines
    // public ICollection<InvoiceLine> InvoiceLines { get; set; }
}