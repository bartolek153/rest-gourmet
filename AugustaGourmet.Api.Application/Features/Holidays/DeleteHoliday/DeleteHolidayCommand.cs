using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Holidays.DeleteHoliday;

public record DeleteHolidayCommand(int[] Ids) : IRequest<ErrorOr<Unit>>;