namespace AugustaGourmet.Api.Application.Features.Receipts.GetReceiptLines;

public class ReceiptLineDto
{
    public int ReceiptId { get; set; }
    public string PartnerProductId { get; set; } = string.Empty;
    public string PartnerProductDescription { get; set; } = string.Empty;
    public double OrderedQuantity { get; set; }
    public double UnitPrice { get; set; }
    public double TotalAmount { get; set; }
    public double IcmsAmount { get; set; }
    public double IcmsRate { get; set; }
    public double IpiAmount { get; set; }
    public double IpiRate { get; set; }
}