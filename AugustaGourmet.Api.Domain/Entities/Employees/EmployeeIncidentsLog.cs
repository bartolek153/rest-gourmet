namespace AugustaGourmet.Api.Domain.Entities.Employees;

[Table("TCAD_FOLGA_FUNCIONARIO")]
public class EmployeeIncidentsLog : BaseEntity
{
    [Column("DataInicio")]
    public DateTime FromDate { get; set; }

    [Column("DataFim")]
    public DateTime ToDate { get; set; }

    [Column("FUNCIONARIO")]
    public Employee Employee { get; set; } = null!;

    [Column("MOTIVO_OCORRENCIA")]
    public EmployeeIncidentReason Reason { get; set; } = null!;

    [Column("Observacao")]
    public string Note { get; set; } = string.Empty;
}