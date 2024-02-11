namespace AugustaGourmet.Api.Application.DTOs.Receipts;

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