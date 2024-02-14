using AugustaGourmet.Api.Application.Common;
using AugustaGourmet.Api.Application.DTOs.Units;

namespace AugustaGourmet.Api.Application.Features.Units.GetUnits;

public class GetUnitsMeasureQuery : PagedQuery<UnitMeasureDto>
{
    public string? Description { get; set; }

    public GetUnitsMeasureQuery(int page, int pageSize, string? q = null) : base(page, pageSize)
    {
        Description = q;
    }
}