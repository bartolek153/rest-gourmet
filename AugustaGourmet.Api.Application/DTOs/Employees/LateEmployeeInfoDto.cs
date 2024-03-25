namespace AugustaGourmet.Api.Application.DTOs.Employees;

public class LateEmployeeInfoDto
{
    public int EmployeeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public double TotalMinutesLate { get; set; }
    public string? ArrivalTime { get; set; }
}