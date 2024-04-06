namespace AugustaGourmet.Api.Domain.Enums;

[Table("TCAD_STATUS_GERAL")]
public class Status : BaseEntity
{
    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;  // Description
}