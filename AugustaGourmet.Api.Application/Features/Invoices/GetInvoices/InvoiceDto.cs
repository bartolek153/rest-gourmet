
public class InvoiceDto
{

    public int Id { get; set; }
    public string Supplier { get; set; } = string.Empty;
    public int NotaFiscal { get; set; }
    public DateTime IssuanceDate { get; set; }
    public double TotalAmount { get; set; }
    public double NetAmount { get; set; }
}