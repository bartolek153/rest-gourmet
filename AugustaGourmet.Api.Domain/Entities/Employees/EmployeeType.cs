namespace AugustaGourmet.Api.Domain.Entities.Employees;

public class EmployeeType : BaseEntity
{
    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;
}