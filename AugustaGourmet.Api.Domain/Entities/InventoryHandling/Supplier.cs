using AugustaGourmet.Api.Domain.Entities.Companies;
using AugustaGourmet.Api.Domain.Entities.Others;
using AugustaGourmet.Api.Domain.Enums;

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
    public string EMAIL_FISCAL { get; set; }
    public string NOME_CONTATO { get; set; }
    public Companies.Company CODIGO_EMPRESA { get; set; }
    public TCAD_STATUS_GERAL CODIGO_STATUS { get; set; }
    public TCAD_FREQUENCIA FREQUENCIA { get; set; }
    public TCAD_DIA_SEMANA DIA_SEMANA { get; set; }
    // public TCAD_FUNCIONARIO FUNCIONARIO { get; set; }
    public int FATOR_KILO { get; set; }
}