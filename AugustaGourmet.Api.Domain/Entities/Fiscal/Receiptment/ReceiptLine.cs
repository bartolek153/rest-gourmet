
namespace AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;

[Table("TCAD_NOTA_FISCAL_LINHA")]
public class ReceiptLine : BaseEntity
{
    [Column("Capa_Id")]
    public int ReceiptId { get; set; }
    [ForeignKey("ReceiptId")]
    public Receipt ReceiptHeader { get; set; } = null!;
    // public Invoice InvoiceHeader { get; set; } = null!;

    [Column("CodigoProduto")]
    public string ProductId { get; set; } = string.Empty;

    [Column("DescricaoProduto")]
    public string ProductDescription { get; set; } = string.Empty;
    // public Product Produto { get; set; }

    [Column("UnidadeCompra")]
    public string UnitMeasure { get; set; } = string.Empty;

    [Column("QuantidadeCompra")]
    public double OrderedQuantity { get; set; }


    [Column("ValorUnitario")]
    public double UnitPrice { get; set; }
    [Column("ValorTotal")]
    public double TotalAmount { get; set; }

    [Column("ValorICMS")]
    public double IcmsAmount { get; set; }
    [Column("AliquotaICMS")]
    public double IcmsRate { get; set; }

    [Column("ValorIPI")]
    public double IpiAmount { get; set; }
    [Column("AliquotaIPI")]
    public double IpiRate { get; set; }
}