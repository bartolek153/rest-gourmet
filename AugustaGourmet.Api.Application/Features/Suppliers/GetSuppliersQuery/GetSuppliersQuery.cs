
using AugustaGourmet.Api.Application.Common;

namespace AugustaGourmet.Api.Application.Features.Suppliers.GetSuppliersQuery;

public class GetSuppliersQuery : PagedQuery<SupplierDto>
{
    public string? Name { get; set; }

    public GetSuppliersQuery(int page, int pageSize, string? name) : base(page, pageSize)
    {
        Name = name;
    }
}