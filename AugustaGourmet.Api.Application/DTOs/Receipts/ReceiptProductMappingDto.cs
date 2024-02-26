using System.ComponentModel.DataAnnotations.Schema;

namespace AugustaGourmet.Api.Application.DTOs.Receipts;

public class ReceiptProductMappingDto
{
    public int Id { get; set; }
    public string PartnerProductId { get; set; } = string.Empty;
    public string PartnerProductDescription { get; set; } = string.Empty;
    public int? InventoryProductId { get; set; }

    [NotMapped]
    public bool CreateProduct { get; set; }
}