using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Holidays.UpdateHoliday;

public class UpdateHolidayCommand : IRequest<ErrorOr<Unit>>
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}