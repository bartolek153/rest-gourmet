using AugustaGourmet.Api.Application.Common;
using AugustaGourmet.Api.Application.DTOs.Inventory;

namespace AugustaGourmet.Api.Application.Features.InventoryParameters.GetInventoryParametersQuery;

public class GetInventoryParametersQuery : PagedQuery<InventoryParameterDto>
{
    public string? Product { get; set; }
    public int? SupplierId { get; set; }
    public int? ProductFamilyId { get; set; }
    public int? ProductGroupId { get; set; }

    public GetInventoryParametersQuery(int page,
                                       int pageSize,
                                       string? product,
                                       int? supplierId,
                                       int? productFamilyId,
                                       int? productGroupId) : base(page, pageSize)
    {
        Product = product;
        SupplierId = supplierId;
        ProductFamilyId = productFamilyId;
        ProductGroupId = productGroupId;
    }
}