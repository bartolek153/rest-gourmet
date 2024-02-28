using AugustaGourmet.Api.Domain.Entities.Employees;

namespace AugustaGourmet.Api.Application.DTOs.Employees;

public class EmployeeDetailsDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Status { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime? DismissalDate { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int WorksSaturdays { get; set; }  // TODO: Change to bool
    public DateTime? SaturdayStartTime { get; set; }
    public DateTime? SaturdayEndTime { get; set; }
    public DateTime LunchTime { get; set; }
    public DateTime MaxOvertimeHoursAllowed { get; set; }
    public int TypeId { get; set; }
    public EmployeeType Type { get; set; } = null!;
}