using AugustaGourmet.Api.Domain.Entities.Employees;
using AugustaGourmet.Api.Domain.Entities.General;
using AugustaGourmet.Api.Domain.Enums;

namespace AugustaGourmet.Api.Domain.Entities.Activities;

[Table("TCAD_PLANO_ATIVIDADE")]
public class ActivityPlan : BaseEntity
{
    public Local LOCAL { get; set; }
    public Status STATUS { get; set; }
    public int QUANTIDADE_REPETICOES { get; set; }
    public Frequency FREQUENCIA { get; set; }
    public DateTime HORARIO { get; set; }
    public DateTime HORARIO_FIM { get; set; }
    public TCAD_DIA_SEMANA DIA_SEMANA { get; set; }
    public string DESCRICAO { get; set; }
    public EmployeeGroup GRUPO_FUNCIONARIO { get; set; }
    public decimal REPETICOES_HORA_MIN { get; set; }
}