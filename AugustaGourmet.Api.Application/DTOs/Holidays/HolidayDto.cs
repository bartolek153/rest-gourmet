namespace AugustaGourmet.Api.Application.DTOs.Holidays;

public class HolidayDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}