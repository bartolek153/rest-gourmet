using AugustaGourmet.Api.Domain.Entities.Companies;

namespace AugustaGourmet.Api.Domain.Entities.Employees;

[Table("TCAD_GRUPO_FUNCIONARIO")]
public class EmployeeGroup : BaseEntity
{
    [Column("CODIGO_EMPRESA")]
    public Company Company { get; set; } = null!;

    [Column("DESCRICAO")]
    public string Description { get; set; } = null!;
}