namespace AugustaGourmet.Api.Application.DTOs.Employees;

public class EmployeeAttendanceDetailsDto
{
    public int Id { get; set; }
    public EmployeeInfoDto EmployeeInfo { get; set; } = null!;
    public List<WorkingDaysDto> WorkingDays { get; set; } = new();
}

public class EmployeeInfoDto
{
    public string Name { get; set; } = string.Empty;
    public string StartTime { get; set; } = string.Empty;
    public string EndTime { get; set; } = string.Empty;
    public int MaxOvertimeHoursAllowed { get; set; }
    public bool WorksSaturdays { get; set; }
    public string SaturdayStartTime { get; set; } = string.Empty;
    public string SaturdayEndTime { get; set; } = string.Empty;
}

public class WorkingDaysDto
{
    public DateTime Date { get; set; }
    public string ShortWeekDay { get; set; } = string.Empty;
    public string TimeIn { get; set; } = string.Empty;
    public string TimeOut { get; set; } = string.Empty;
    public int LateMinutes { get; set; }
    public int OvertimeMinutes { get; set; }
    public string IncidentReason { get; set; } = string.Empty;
    public string ConditionalFormatHex { 
        get {
            if (LateMinutes == 0) return "#00FF00";
            if (LateMinutes <= 5) return "#FFFF00";
            return "#FF0000";
        } 
    }
}
