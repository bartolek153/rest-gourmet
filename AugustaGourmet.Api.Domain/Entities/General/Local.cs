using AugustaGourmet.Api.Domain.Entities.Companies;

namespace AugustaGourmet.Api.Domain.Entities.General;

[Table("TCAD_LOCAL")]
public class Local : BaseEntity
{
    [Column("CODIGO_EMPRESA")]
    public Company Company { get; set; } = null!;

    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;
}