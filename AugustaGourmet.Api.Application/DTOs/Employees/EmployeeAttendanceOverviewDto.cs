namespace AugustaGourmet.Api.Application.DTOs.Employees;

public class EmployeeAttendanceOverviewDto
{
    // public TimeSpan? test { get; set; }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime TimeIn { get; set; }
    public DateTime TimeOut { get; set; }
    public bool WorksSaturdays { get; set; }
    public int Absences { get; set; }
    public int LateArrivalCount { get; set; }
    public int LateMinutes { get; set; }
    public int OvertimeMinutes { get; set; }
    public int BalanceMinutes { get; set; }
}