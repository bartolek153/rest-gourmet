namespace AugustaGourmet.Api.Domain.Entities.Employees;

[Table("TCAD_TIPO_ATRASO")]
public class EmployeeDelayType : BaseEntity
{
    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;
}