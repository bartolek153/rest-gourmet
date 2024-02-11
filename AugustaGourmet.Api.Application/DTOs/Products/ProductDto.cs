namespace AugustaGourmet.Api.Application.DTOs.Products;

public class ProductDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Group { get; set; } = string.Empty;
    public string PurchaseUnit { get; set; } = string.Empty;
    public string UnitMeasure { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal PurchasePrice { get; set; }
}