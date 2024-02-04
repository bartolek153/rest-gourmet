
namespace AugustaGourmet.Api.Application.Features.Receipts.GetReceipts;

public class ReceiptDto
{

    public int Id { get; set; }
    public string Supplier { get; set; } = string.Empty;
    public int DocumentNumber { get; set; }
    public int Serie { get; set; }
    public DateTime IssueDate { get; set; }
    public double TotalAmount { get; set; }
    public double NetAmount { get; set; }
}