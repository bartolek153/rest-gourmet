namespace AugustaGourmet.Api.Domain.Entities.Employees;

[Table("TCAD_FOLGA_FUNCIONARIO")]
public class TCAD_FOLGA_FUNCIONARIO
{
    [Column("DataInicio")]
    public DateTime FromDate { get; set; }

    [Column("DataFim")]
    public DateTime ToDate { get; set; }

    [Column("FUNCIONARIO")]
    public Employee Employee { get; set; } = null!;

    [Column("MOTIVO_OCORRENCIA")]
    public TCAD_MOTIVO_OCORRENCIA Reason { get; set; }

    [Column("Observacao")]
    public string Note { get; set; } = string.Empty;
}