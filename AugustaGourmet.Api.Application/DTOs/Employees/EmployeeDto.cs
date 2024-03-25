namespace AugustaGourmet.Api.Application.DTOs.Employees;

public class EmployeeDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime HireDate { get; set; }
}