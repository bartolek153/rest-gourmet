namespace AugustaGourmet.Api.Domain.Entities.Alerts;

public class BaseAlert : BaseEntity
{
    public string? Message { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [Column("Type_Id")]
    public int TypeId { get; set; }
}