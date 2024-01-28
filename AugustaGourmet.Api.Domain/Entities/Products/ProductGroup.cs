namespace AugustaGourmet.Api.Domain.Entities.Products;

[Table("TCAD_GRUPO_PRODUTO")]
public class ProductGroup : BaseEntity
{
    [Column("EMPRESA_Id")]
    public int CompanyId { get; set; }

    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;

    [Column("FAMILIA_Id")]
    public int FamilyId { get; set; }

    [NotMapped]
    public int FINALIZADO_INVENTARIO { get; set; }
    [NotMapped]
    public int POSSUI_ITENS_OBRIGATORIO { get; set; }
}