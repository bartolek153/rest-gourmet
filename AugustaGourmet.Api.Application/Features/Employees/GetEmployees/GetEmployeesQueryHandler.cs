using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Employees;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Employees.GetEmployees;

public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, PagedList<EmployeeDto>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _employeeRepository.GetAllWithPaginationAsync(
            filter: e => string.IsNullOrWhiteSpace(request.Name) || e.Name.Contains(request.Name),
            orderBy: e => e.OrderBy(e => e.Name),
            startPage: request.Page,
            perPage: request.PageSize
        );

        return new PagedList<EmployeeDto>(
            _mapper.Map<List<EmployeeDto>>(employees.Items),
            employees.TotalCount,
            employees.Page,
            employees.PageSize);
    }
}