using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Holidays.CreateHoliday;

public class CreateHolidayCommand : IRequest<ErrorOr<int>>
{
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}