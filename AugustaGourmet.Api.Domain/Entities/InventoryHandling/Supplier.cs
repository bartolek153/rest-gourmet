using AugustaGourmet.Api.Domain.Enums;

namespace AugustaGourmet.Api.Domain.Entities.InventoryHandling;

[Table("TCAD_FORNECEDOR")]
public class Supplier : BaseEntity
{
    [Column("CODIGO_EMPRESA_Id")]
    public int CompanyId { get; set; }

    [Column("DESCRICAO")]
    public string Name { get; set; } = string.Empty;

    [Column("APELIDO")]
    public string TradeName { get; set; } = string.Empty;

    [Column("CNPJ")]
    public string CNPJ { get; set; } = string.Empty;

    [Column("FONE_FIXO")]
    public string? LandlinePhone { get; set; } = string.Empty;

    [Column("WHATSAPP")]
    public string? MobilePhone { get; set; } = string.Empty;

    [Column("EMAIL")]
    public string? ContactEmail { get; set; } = string.Empty;

    [Column("EMAIL_FISCAL")]
    public string? FiscalEmail { get; set; } = string.Empty;

    [Column("NOME_CONTATO")]
    public string? ContactName { get; set; } = string.Empty;

    [Column("CODIGO_STATUS_Id")]
    public int StatusId { get; set; }
    [ForeignKey("StatusId")]
    public Status Status { get; set; } = null!;

    [Column("FREQUENCIA_Id")]
    public int InventoryFrequencyId { get; set; }

    [Column("DIA_SEMANA_Id")]
    public int InventoryWeekDay { get; set; }

    [Column("FUNCIONARIO_Id")]
    public int EmployeeId { get; set; }

    public int FATOR_KILO { get; set; } // TODO: check column use
}