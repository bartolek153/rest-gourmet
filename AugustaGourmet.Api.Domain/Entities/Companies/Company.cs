namespace AugustaGourmet.Api.Domain.Entities.Companies;

[Table("TCAD_EMPRESA")]
public class Company : BaseEntity
{
    // Identification
    [Column("RAZAO_SOCIAL")]
    public string RAZAO_SOCIAL { get; set; } = string.Empty;

    [Column("NOME_FANTASIA")]
    public string TradingName { get; set; } = string.Empty;

    [Column("INSCRICAO_ESTADUAL")]
    public string StateRegistration { get; set; } = string.Empty;

    public string CNPJ { get; set; } = string.Empty;

    [Column("TIPO")]
    public CompanyType Type { get; set; } = null!;

    // Contact
    [Column("TELEFONE")]
    public string PhoneNumber { get; set; } = string.Empty;
    // public string? Email { get; set; }

    // Extra ???
    public string SENHA_LIBERACAO { get; set; } = string.Empty;
}