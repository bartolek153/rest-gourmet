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

    [Column("TIPO_Id")]
    public int TypeId { get; set; }

    // Contact
    [Column("TELEFONE")]
    public string PhoneNumber { get; set; } = string.Empty;

    // TODO: create user adminstrator field

    // Extra ???
    public string SENHA_LIBERACAO { get; set; } = string.Empty;
}