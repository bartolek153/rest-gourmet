namespace AugustaGourmet.Api.Application.DTOs.Inventory;

public class InventoryParameterDto
{
    public string Id { get; set; }
    public string Product { get; set; } = string.Empty;
    public string Supplier { get; set; } = string.Empty;
    public double MinStockQuantity { get; set; }
    public string MinStockUnit { get; set; } = string.Empty;
    public double MaxStockQuantity { get; set; }
    public string MaxStockUnit { get; set; } = string.Empty;
    public bool CountIsMandatory { get; set; }
}