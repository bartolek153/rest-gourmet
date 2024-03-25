using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Employees;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.EmployeesIncidents.GetEmployeesIncidents;

public class GetEmployeesIncidentsQueryHandler : IRequestHandler<GetEmployeesIncidentsQuery, PagedList<EmployeeIncidentLogDto>>
{
    private readonly IEmployeeIncidentRepository _employeeIncidentRepository;
    private readonly IMapper _mapper;

    public GetEmployeesIncidentsQueryHandler(IEmployeeIncidentRepository employeeIncidentRepository, IMapper mapper)
    {
        _employeeIncidentRepository = employeeIncidentRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<EmployeeIncidentLogDto>> Handle(GetEmployeesIncidentsQuery request, CancellationToken cancellationToken)
    {
        if (request.From.HasValue && request.To.HasValue && request.From > request.To)
            request.To = request.From.Value.AddDays(1);

        var incidents = await _employeeIncidentRepository.GetAllWithPaginationAsync(
            filter: x => (!request.From.HasValue || x.FromDate >= request.From) &&
                         (!request.To.HasValue || x.ToDate <= request.To) &&
                         (!request.EmployeeId.HasValue || x.EmployeeId == request.EmployeeId),
            orderBy: q => q.OrderByDescending(x => x.FromDate),
            startPage: request.Page,
            perPage: request.PageSize,
            "Employee,Reason");

        return new PagedList<EmployeeIncidentLogDto>(
            _mapper.Map<List<EmployeeIncidentLogDto>>(incidents.Items),
            incidents.TotalCount,
            incidents.Page,
            incidents.PageSize);
    }
}