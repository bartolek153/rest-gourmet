namespace AugustaGourmet.Api.Domain.Entities.Employees;

[Table("TCAD_CONTROLE_FUNCIONARIO")]
public class EmployeeAttendance : BaseEntity
{
    [Column("FUNCIONARIO")]
    public Employee Employee { get; set; } = null!;

    [Column("DATA_APONTAMENTO")]
    public DateTime Date { get; set; }

    [Column("DATA_ENTRADA")]
    public DateTime TimeIn { get; set; }

    [Column("DATA_SAIDA")]
    public DateTime? TimeOut { get; set; }

    [Column("ATRASO")]
    public double DelayMinutes { get; set; }

    [Column("STATUS")]
    public TCAD_STATUS_APT_FUNCIONARIO Status { get; set; }

    [Column("TIPO_ATRASO")]
    public EmployeeDelayType TIPO_ATRASO { get; set; }

    [Column("EXTRA")]
    public double OvertimeMinutes { get; set; }

    [Column("DESCRICAO_ABONO")]
    public string Note { get; set; } = string.Empty;
}