using AugustaGourmet.Api.Domain.Entities.Companies;

namespace AugustaGourmet.Api.Domain.Entities.General;

[Table("TCAD_FERIADOS")]
public class Holiday : BaseEntity
{
    [Column("CODIGO_EMPRESA_Id")]
    public int CompanyId { get; set; }

    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;

    [Column("DATA")]
    public DateTime Date { get; set; }

    [ForeignKey("CompanyId")]
    public Company Company { get; set; } = null!;
}