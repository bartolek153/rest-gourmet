namespace AugustaGourmet.Api.Domain.Entities.Units;

public class TCAD_UNIDADE_MEDIDA : BaseEntity  // m, L, Kg, g ...
{
    public string DESCRICAO { get; set; } = string.Empty;  // Description!
    public string DESCRICAO_RESUMIDA { get; set; } = string.Empty;  // ShortDescription!
}