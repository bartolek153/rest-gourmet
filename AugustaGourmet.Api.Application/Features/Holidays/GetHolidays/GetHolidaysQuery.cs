using AugustaGourmet.Api.Application.Common;
using AugustaGourmet.Api.Application.DTOs.Holidays;

namespace AugustaGourmet.Api.Application.Features.Holidays.GetHolidays;

public class GetHolidaysQuery : PagedQuery<HolidayDto>
{
    public GetHolidaysQuery(int page, int perPage) : base(page, perPage)
    {
    }
}