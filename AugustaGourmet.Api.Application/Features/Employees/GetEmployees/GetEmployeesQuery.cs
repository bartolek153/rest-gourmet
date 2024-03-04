using AugustaGourmet.Api.Application.Common;
using AugustaGourmet.Api.Application.DTOs.Employees;

namespace AugustaGourmet.Api.Application.Features.Employees.GetEmployees;

public class GetEmployeesQuery : PagedQuery<EmployeeDto>
{
    public string? Name { get; set; }

    public GetEmployeesQuery(string? name, int pageNumber, int pageSize) : base(pageNumber, pageSize)
    {
        Name = name;
    }
}
