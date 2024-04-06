using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Holidays;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Holidays.GetHolidays;

public class GetHolidaysQueryHandler : IRequestHandler<GetHolidaysQuery, PagedList<HolidayDto>>
{
    private readonly IHolidayRepository _holidayRepository;
    private readonly IMapper _mapper;

    public GetHolidaysQueryHandler(IHolidayRepository holidayRepository, IMapper mapper)
    {
        _holidayRepository = holidayRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<HolidayDto>> Handle(GetHolidaysQuery request, CancellationToken cancellationToken)
    {
        var holidays = await _holidayRepository.GetAllWithPaginationAsync(
            filter: null,
            orderBy: x => x.OrderByDescending(y => y.Date),
            perPage: request.PageSize,
            startPage: request.Page);

        return new PagedList<HolidayDto>(
            _mapper.Map<List<HolidayDto>>(holidays.Items),
            holidays.TotalCount,
            holidays.Page,
            holidays.PageSize);
    }
}