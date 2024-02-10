namespace AugustaGourmet.Api.Domain.Entities.Companies;

[Table("TIPO_EMPRESA")]
public class CompanyType : BaseEntity
{
    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;
}