namespace AugustaGourmet.Api.Domain.Entities.Employees;

[Table("TCAD_STATUS_FUNCIONARIO")]
public class EmployeeStatus : BaseEntity
{
    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;
}