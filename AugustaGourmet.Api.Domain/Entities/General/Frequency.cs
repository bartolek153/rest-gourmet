namespace AugustaGourmet.Api.Domain.Entities.General;

[Table("TCAD_FREQUENCIA")]
public class Frequency : BaseEntity
{
    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;

    [Column("QUANTIDADE_DIAS")]
    public int DaysConversion { get; set; }  // TODO:  nullable
}