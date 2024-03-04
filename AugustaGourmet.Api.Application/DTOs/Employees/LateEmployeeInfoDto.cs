namespace AugustaGourmet.Api.Application.DTOs.Employees;

public class LateEmployeeInfoDto
{
    public string Name { get; set; } = string.Empty;
    public double TotalMinutesLate { get; set; }
    public string? TimeIn { get; set; }
}