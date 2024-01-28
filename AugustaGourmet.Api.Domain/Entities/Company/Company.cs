namespace AugustaGourmet.Api.Domain.Entities.Company;

public class TCAD_EMPRESA : BaseEntity
{
    // Identification
    public string RAZAO_SOCIAL { get; set; } = string.Empty;  // CorporateName!
    public string NOME_FANTASIA { get; set; } = string.Empty;  // TradingName?
    public string INSCRICAO_ESTADUAL { get; set; } = string.Empty;  // StateRegistration?
    public string CNPJ { get; set; } = string.Empty;  // CNPJ?
    public TIPO_EMPRESA TIPO { get; set; }  // CompanyType!

    // Contact
    public string TELEFONE { get; set; } = string.Empty;  // PhoneNumber?
    // public string? Email { get; set; }

    // Extra
    public string SENHA_LIBERACAO { get; set; } = string.Empty;
}