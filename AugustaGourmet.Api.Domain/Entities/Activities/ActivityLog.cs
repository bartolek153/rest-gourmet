using AugustaGourmet.Api.Domain.Entities.Employees;

using WebAPI.Models;

namespace AugustaGourmet.Api.Domain.Entities.Activities;

[Table("TCAD_EXECUCAO_PLANO_ATIVIDADE")]
public class ActivityLog : BaseEntity
{
    [Column("PLANO_ATIVIDADE")]
    public ActivityPlan Plan { get; set; } = null!;

    [Column("STATUS")]
    public ActivityPlanStatus Status { get; set; } = null!;

    [Column("DATA_CRIACAO")]
    public DateTime CreationDate { get; set; }

    [Column("DATA_FINALIZACAO")]
    public DateTime? CompletionDate { get; set; }

    [Column("FUNCIONARIO")]
    public Employee Employee { get; set; } = null!;

    [Column("DATA_EXECUCAO")]
    public DateTime StartDate { get; set; }

    [Column("DATA_EXECUCAO_INICIAL")]
    public DateTime EndDate { get; set; }

    [NotMapped]
    public List<TCAD_PLANO_ATIVIDADE_ITEM> Items { get; set; } = null!;
}