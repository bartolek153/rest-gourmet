﻿namespace AugustaGourmet.Api.Domain.Entities.Employees;

[Table("TCAD_STATUS_APT_FUNCIONARIO")]
public class TCAD_STATUS_APT_FUNCIONARIO : BaseEntity
{
    [Column("DESCRICAO")]
    public string Description { get; set; } = string.Empty;
}