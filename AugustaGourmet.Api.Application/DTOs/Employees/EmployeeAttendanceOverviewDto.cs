namespace AugustaGourmet.Api.Application.DTOs.Employees;

public class EmployeeAttendanceOverviewDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string TimeIn { get; set; } = string.Empty;
    public string TimeOut { get; set; } = string.Empty;
    public bool WorksSaturdays { get; set; }

    public int WorkedDays { get; set; }
    public int IncidentDays { get; set; }
    public int MandatedWorkDays { get; set; }
    public int AbsenceDays { get => MandatedWorkDays - WorkedDays; }

    public int LateArrivalCount { get; set; }
    public int LateMinutes { get; set; }
    public int OvertimeMinutes { get; set; }
}