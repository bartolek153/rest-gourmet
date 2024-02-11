namespace AugustaGourmet.Api.Domain.Entities.Employees;

[Table("TCAD_MOTIVO_OCORRENCIA")]
public class EmployeeIncidentReason : BaseEntity
{
    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;
}