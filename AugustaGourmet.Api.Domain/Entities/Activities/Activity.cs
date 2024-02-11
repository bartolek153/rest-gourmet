using AugustaGourmet.Api.Domain.Entities.Companies;

namespace AugustaGourmet.Api.Domain.Entities.Activities;

[Table("TCAD_ATIVIDADE")]
public class Activity : BaseEntity
{
    [Column("CODIGO_EMPRESA")]
    public Company Company { get; set; } = null!;

    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;
}