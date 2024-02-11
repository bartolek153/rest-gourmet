using AugustaGourmet.Api.Domain.Entities.Companies;

namespace AugustaGourmet.Api.Domain.Entities.Activities.Equipment;

public class TCAD_EQUIPAMENTO : BaseEntity
{
    public Company CODIGO_EMPRESA { get; set; }

    public string DESCRICAO { get; set; } = string.Empty;  // Description!
    public TCAD_TIPO_EQUIPAMENTO TIPO_EQUIPAMENTO { get; set; }  // EquipmentType!
}