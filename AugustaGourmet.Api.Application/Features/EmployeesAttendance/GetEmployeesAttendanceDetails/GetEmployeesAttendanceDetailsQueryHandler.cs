using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Employees;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.EmployeesAttendance.GetEmployeesAttendanceDetails;

public class GetEmployeesAttendanceDetailsQueryHandler : IRequestHandler<GetEmployeesAttendanceDetailsQuery, ErrorOr<EmployeeAttendanceDetailsDto>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeesAttendanceDetailsQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<ErrorOr<EmployeeAttendanceDetailsDto>> Handle(GetEmployeesAttendanceDetailsQuery request, CancellationToken cancellationToken)
    {
        // TODO: check if the employee exists
        return await _employeeRepository.GetEmployeeAttendanceDetailsAsync(request.Employee, request.From, request.To);
    }
}