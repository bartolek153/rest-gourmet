using AugustaGourmet.Api.Domain.Entities.Companies;
using AugustaGourmet.Api.Domain.Entities.Others;

namespace AugustaGourmet.Api.Domain.Entities.InventoryHandling;

[Table("TCAD_FORNECEDOR")]
public class Supplier : BaseEntity
{
    [Column("DESCRICAO")]
    public string Name { get; set; } = string.Empty;

    public string APELIDO { get; set; }
    public string CNPJ { get; set; }
    public string FONE_FIXO { get; set; }
    public string WHATSAPP { get; set; }
    public string EMAIL { get; set; }

    [Column("EMAIL_FISCAL")]
    public string FiscalEmail { get; set; } = string.Empty;
    public string NOME_CONTATO { get; set; }
    public Company CODIGO_EMPRESA { get; set; }

    [Column("CODIGO_STATUS_Id")]
    public int Status { get; set; }

    public TCAD_FREQUENCIA FREQUENCIA { get; set; }
    public TCAD_DIA_SEMANA DIA_SEMANA { get; set; }
    // public TCAD_FUNCIONARIO FUNCIONARIO { get; set; }
    public int FATOR_KILO { get; set; }
}