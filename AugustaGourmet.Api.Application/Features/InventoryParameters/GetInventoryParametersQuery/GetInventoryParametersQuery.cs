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
                                       string? product = null,
                                       int? supplierId = null,
                                       int? productFamilyId = null,
                                       int? productGroupId = null) : base(page, pageSize)
    {
        Product = product;
        SupplierId = supplierId;
        ProductFamilyId = productFamilyId;
        ProductGroupId = productGroupId;
    }
}