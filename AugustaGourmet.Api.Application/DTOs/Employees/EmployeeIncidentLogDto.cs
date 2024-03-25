namespace AugustaGourmet.Api.Application.DTOs.Employees;

public class EmployeeIncidentLogDto
{
    public int Id { get; set; }
    public string? EmployeeName { get; set; }
    public string Reason { get; set; } = string.Empty;
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public string? Note { get; set; }
}