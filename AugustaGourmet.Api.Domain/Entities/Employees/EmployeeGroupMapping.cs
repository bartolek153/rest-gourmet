namespace AugustaGourmet.Api.Domain.Entities.Employees;

[Table("TCAD_FUNC_GRUPO_RELACAO")]
public class EmployeeGroupMapping
{
    [Column("FUNCIONARIOId")]
    public int EmployeeId { get; set; }

    [Column("GRUPO_FUNCIONARIOId")]
    public int EmployeeGroupId { get; set; }
}