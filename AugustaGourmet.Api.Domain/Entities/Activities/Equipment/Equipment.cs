using AugustaGourmet.Api.Domain.Entities.Company;

namespace AugustaGourmet.Api.Domain.Entities.Activities.Equipment;

public class TCAD_EQUIPAMENTO : BaseEntity
{
    public TCAD_EMPRESA CODIGO_EMPRESA { get; set; }

    public string DESCRICAO { get; set; } = string.Empty;  // Description!
    public TCAD_TIPO_EQUIPAMENTO TIPO_EQUIPAMENTO { get; set; }  // EquipmentType!
}