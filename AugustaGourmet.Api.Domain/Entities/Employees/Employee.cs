using AugustaGourmet.Api.Domain.Entities.Companies;

namespace AugustaGourmet.Api.Domain.Entities.Employees;

public class Employee : BaseEntity
{
    [Column("EMPRESA")]
    public Company Company { get; set; } = null!;
    [Column("NOME")]
    public string Name { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    [Column("EMAIL")]
    public string Email { get; set; } = string.Empty;
    [Column("SENHA")]
    public string Password { get; set; } = string.Empty;
    [Column("STATUS")]
    public EmployeeStatus Status { get; set; } = null!;

    [Column("DATA_ADMISSAO")]
    public DateTime HireDate { get; set; }
    [Column("DATA_DEMISSAO")]
    public DateTime? DismissalDate { get; set; }

    [Column("HORA_INICIO")]
    public DateTime StartTime { get; set; }
    [Column("HORA_FIM")]
    public DateTime EndTime { get; set; }
    [Column("TRABALHA_SABADO")]
    public int WorksSaturday { get; set; }
    [Column("HORARIO_ENRADA_SABADO")]
    public DateTime? SaturdayStartTime { get; set; }
    [Column("HORARIO_SAIDA_SABADO")]
    public DateTime? SaturdayEndTime { get; set; }
    [Column("HORARIO_ALMOCO")]
    public DateTime LunchTime { get; set; }
    [Column("HORA_EXTRA")]
    public DateTime MaxOvertimeHoursAllowed { get; set; }

    [Column("TIPO_FUNCIONARIO")]
    public EmployeeType Type { get; set; } = null!;
}
