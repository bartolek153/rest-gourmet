namespace AugustaGourmet.Api.Domain.Entities.Employees;

[Table("TCAD_FUNCIONARIO")]
public class Employee : BaseEntity
{
    [Column("EMPRESA_Id")]
    public int CompanyId { get; set; }

    [Column("NOME")]
    public string Name { get; set; } = string.Empty;

    [Column("CPF")]
    public string CPF { get; set; } = string.Empty;

    [Column("EMAIL")]
    public string Email { get; set; } = string.Empty;

    [Column("SENHA")]
    public string Password { get; set; } = string.Empty;

    [Column("STATUS_Id")]
    public int Status { get; set; }

    [Column("DATA_ADMISSAO")]
    public DateTime HireDate { get; set; }

    [Column("DATA_DEMISSAO")]
    public DateTime? DismissalDate { get; set; }

    [Column("HORA_INICIO")]
    public DateTime StartTime { get; set; }

    [Column("HORA_FIM")]
    public DateTime EndTime { get; set; }

    [Column("TRABALHA_SABADO")]
    public int WorksSaturdays { get; set; }  // TODO: Change to bool

    [Column("HORARIO_ENTRADA_SABADO")]
    public DateTime? SaturdayStartTime { get; set; }

    [Column("HORARIO_SAIDA_SABADO")]
    public DateTime? SaturdayEndTime { get; set; }

    [Column("HORARIO_ALMOCO")]
    public DateTime LunchTime { get; set; }

    [Column("HORA_EXTRA")]
    public DateTime MaxOvertimeHoursAllowed { get; set; }

    [Column("TIPO_FUNCIONARIO_Id")]
    public int TypeId { get; set; }
    [ForeignKey("TypeId")]
    public EmployeeType Type { get; set; } = null!;
}

// https://www.sk.com.br/sk-hr.html - HR enus -> ptbr glossary