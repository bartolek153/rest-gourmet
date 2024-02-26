namespace AugustaGourmet.Api.Domain.Entities.Employees;

[Table("TCAD_FOLGA_FUNCIONARIO")]
public class EmployeeIncidentLog : BaseEntity
{
    [Column("DataInicio")]
    public DateTime FromDate { get; set; }

    [Column("DataFim")]
    public DateTime ToDate { get; set; }

    [Column("FUNCIONARIO_Id")]
    public int? EmployeeId { get; set; }

    [Column("MOTIVO_OCORRENCIA_Id")]
    public int ReasonId { get; set; }
    [ForeignKey("ReasonId")]
    public EmployeeIncidentReason Reason { get; set; } = null!;

    [Column("Observacao")]
    public string? Note { get; set; } = string.Empty;
}