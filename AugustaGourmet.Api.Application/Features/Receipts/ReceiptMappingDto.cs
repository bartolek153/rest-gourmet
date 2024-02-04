namespace AugustaGourmet.Api.Application.Features.Receipts;

public class ReceiptMappingDto
{
    public int Id { get; set; }
    public List<ReceiptProductMappingDto> Mappings { get; set; } = null!;
}