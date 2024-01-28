using AugustaGourmet.Api.Domain.Enums;

namespace AugustaGourmet.Api.Domain.Entities.Units;

public class TCAD_UNIDADE : BaseEntity
{
    public string DESCRICAO { get; set; } = string.Empty;  // Description!
    public string DESCRICAO_RESUMIDA { get; set; } = string.Empty;  // ShortDescription?

    public TCAD_UNIDADE_MEDIDA UNIDADE_BASE { get; set; }  // BaseMeasure!
    public decimal FATOR_CONVERSAO { get; set; } // = 1;  ConversionFactor
    public decimal FATOR_CONVERSAO_KILO { get; set; } = 1;  // KilogramConversionFactor?

    public int UNIDADE_USO { get; set; }  // ?

    public TCAD_STATUS_GERAL STATUS { get; set; }
}