
namespace AugustaGourmet.Api.Application.Features.Suppliers.GetSuppliersQuery;

public class SupplierDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LandlinePhone { get; set; } = string.Empty;
    public string MobilePhone { get; set; } = string.Empty;
    public string ContactEmail { get; set; } = string.Empty;
    public string ContactName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}