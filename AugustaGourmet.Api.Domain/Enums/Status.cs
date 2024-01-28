namespace AugustaGourmet.Api.Domain.Enums;

public class TCAD_STATUS_GERAL : BaseEntity
{
    public string DESCRICAO { get; set; } = string.Empty;  // Description
}

public enum Status
{
    Ativo = 1,
    Inativo = 2,
    Bloqueado = 3,
    Excluido = 4
}