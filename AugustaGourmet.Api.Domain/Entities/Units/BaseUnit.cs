namespace AugustaGourmet.Api.Domain.Entities.Units;

[Table("TCAD_UNIDADE_MEDIDA")]
public class BaseUnit : BaseEntity  // m, L, Kg, g ...
{
    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;

    [Column("DESCRICAO_RESUMIDA")]
    public string ShortDescription { get; set; } = string.Empty;
}