namespace AugustaGourmet.Api.Domain.Entities.Units;

[Table("TCAD_UNIDADE")]
public class UnitMeasure : BaseEntity
{
    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;

    [Column("DESCRICAO_RESUMIDA")]
    public string ShortDescription { get; set; } = string.Empty;

    [Column("UNIDADE_BASE_Id")]
    public int BaseUnitId { get; set; }

    [Column("FATOR_CONVERSAO")]
    public decimal ConversionFactor { get; set; }

    [Column("FATOR_CONVERSAO_KILO")]
    public decimal KilogramConversionFactor { get; set; } = 1;

    [Column("UNIDADE_USO")]  // TODO: change to bool
    public int UnitInUse { get; set; }

    [Column("STATUS_Id")]
    public int Status { get; set; }
}