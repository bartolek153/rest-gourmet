namespace AugustaGourmet.Api.Application.Features.Receipts.GetReceiptLines;

public class ReceiptLineDto
{
    public int Id { get; set; }
    public int ReceiptId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}