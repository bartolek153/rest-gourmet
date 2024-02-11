using AugustaGourmet.Api.Domain.Entities.Companies;

namespace AugustaGourmet.Api.Domain.Entities.Activities.Equipment;

public class TCAD_TIPO_EQUIPAMENTO : BaseEntity
{
    public Company CODIGO_EMPRESA { get; set; }

    public string DESCRICAO { get; set; } = string.Empty;  // Description!
}