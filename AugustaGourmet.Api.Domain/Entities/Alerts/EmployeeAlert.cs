namespace AugustaGourmet.Api.Domain.Entities.Alerts;

public class EmployeeAlert : BaseAlert
{
    [Column("Employee_Id")]
    public int EmployeeId { get; set; }
}