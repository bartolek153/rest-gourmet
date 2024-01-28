﻿using AugustaGourmet.Api.Domain.Entities.Activities.Equipment;
using AugustaGourmet.Api.Domain.Entities.Company;

namespace AugustaGourmet.Api.Domain.Entities.Products;

[Table("TCAD_CATEGORIA_PRODUTO")]
public class ProductCategory : BaseEntity
{
    [Column("EMPRESA_Id")]
    public int? CompanyId { get; set; }
    [ForeignKey("CompanyId")]
    public TCAD_EMPRESA Company { get; set; } = null!;

    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;  // Description!

    public TCAD_IMPRESSORA IMPRESSORA { get; set; }  // Printer?
    public int EXIBIR_CARDAPIO { get; set; }  // ?
}