namespace AugustaGourmet.Api.Domain.Entities.Activities;

[Table("TCAD_STATUS_PLANO_ATIVIDADES")]
public class ActivityPlanStatus : BaseEntity
{
    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;
}