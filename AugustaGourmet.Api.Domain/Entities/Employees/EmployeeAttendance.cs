namespace AugustaGourmet.Api.Domain.Entities.Employees;

[Table("TCAD_CONTROLE_FUNCIONARIO")]
public class EmployeeAttendance : BaseEntity
{
    [Column("FUNCIONARIO_Id")]
    public int EmployeeId { get; set; }

    [Column("DATA_APONTAMENTO")]
    public DateTime Date { get; set; }  //TODO: DateOnly

    [Column("DATA_ENTRADA")]  // TODO: TimeSpan nullable 
    public DateTime TimeIn { get; set; }

    [Column("DATA_SAIDA")]
    public DateTime? TimeOut { get; set; }  // TODO: TimeSpan nullable 

    [Column("ATRASO")]
    public double DelayMinutes { get; set; }

    [Column("STATUS")]
    public EmployeeStatus Status { get; set; } = null!;

    [Column("TIPO_ATRASO")]
    public EmployeeDelayType? DelayType { get; set; } = null!;

    [Column("EXTRA")]
    public double OvertimeMinutes { get; set; }

    [Column("DESCRICAO_ABONO")]
    public string? Note { get; set; } = string.Empty;

    [Column("ALERTA_ATRASO")]
    public bool? SentLateAlert { get; set; }

    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; } = null!;
}