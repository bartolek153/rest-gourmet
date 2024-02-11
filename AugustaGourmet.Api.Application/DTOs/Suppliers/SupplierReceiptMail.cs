namespace AugustaGourmet.Api.Application.DTOs.Suppliers;

public class SupplierReceiptMail
{
    public int SupplierId { get; set; }
    public string EmailAddress { get; set; } = string.Empty;
}