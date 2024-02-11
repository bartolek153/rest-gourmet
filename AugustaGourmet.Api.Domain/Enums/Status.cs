namespace AugustaGourmet.Api.Domain.Enums;

public class TCAD_STATUS_GERAL : BaseEntity
{
    public string DESCRICAO { get; set; } = string.Empty;  // Description
}

public enum Status
{
    Active = 1,
    Inactive = 2
}