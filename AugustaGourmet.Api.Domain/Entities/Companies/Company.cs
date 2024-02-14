namespace AugustaGourmet.Api.Domain.Entities.Companies;

[Table("TCAD_EMPRESA")]
public class Company : BaseEntity
{
    // Identification
    [Column("NOME_FANTASIA")]
    public string Name { get; set; } = string.Empty;

    [Column("RAZAO_SOCIAL")]
    public string CorporativeName { get; set; } = string.Empty;

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