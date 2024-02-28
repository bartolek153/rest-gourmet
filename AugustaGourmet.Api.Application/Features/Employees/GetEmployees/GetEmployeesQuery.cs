using AugustaGourmet.Api.Application.Common;

namespace AugustaGourmet.Api.Application.Features.Employees.GetEmployees;

public class GetEmployeesQuery : PagedQuery<EmployeeDto>
{
    public string? Name { get; set; }

    public GetEmployeesQuery(string? name)
    {
        Name = name;
    }
}
