using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Employees;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.EmployeesAttendance.GetEmployeesAttendanceOverview;

public class GetEmployeesAttendanceOverviewQueryHandler : IRequestHandler<GetEmployeesAttendanceOverviewQuery, ErrorOr<List<EmployeeAttendanceOverviewDto>>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeesAttendanceOverviewQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<ErrorOr<List<EmployeeAttendanceOverviewDto>>> Handle(GetEmployeesAttendanceOverviewQuery request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetEmployeeAttendanceOverviewAsync(request.From, request.To);
    }
}