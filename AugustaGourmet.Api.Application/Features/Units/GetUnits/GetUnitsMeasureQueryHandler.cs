using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Units;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Units.GetUnits;

public class GetUnitsMeasureQueryHandler : IRequestHandler<GetUnitsMeasureQuery, PagedList<UnitMeasureDto>>
{
    private readonly IUnitMeasureRepository _unitMeasureRepository;
    private readonly IMapper _mapper;

    public GetUnitsMeasureQueryHandler(IUnitMeasureRepository unitMeasureRepository, IMapper mapper)
    {
        _unitMeasureRepository = unitMeasureRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<UnitMeasureDto>> Handle(GetUnitsMeasureQuery request, CancellationToken cancellationToken)
    {
        var units = await _unitMeasureRepository.GetAllWithPaginationAsync(
            u => string.IsNullOrEmpty(request.Description) || u.Description.ToLower().Contains(request.Description),
            u => u.OrderBy(u => u.Description),
            request.Page,
            request.PageSize);

        return new PagedList<UnitMeasureDto>(
            _mapper.Map<List<UnitMeasureDto>>(units.Items),
            units.TotalCount,
            request.Page,
            request.PageSize);
    }
}