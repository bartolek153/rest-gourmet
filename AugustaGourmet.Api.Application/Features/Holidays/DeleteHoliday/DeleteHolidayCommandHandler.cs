using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.General;
using AugustaGourmet.Api.Domain.Errors;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Holidays.DeleteHoliday;

public class DeleteHolidayCommandHandler : IRequestHandler<DeleteHolidayCommand, ErrorOr<Unit>>
{
    private readonly IHolidayRepository _holidayRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteHolidayCommandHandler(IHolidayRepository holidayRepository, IUnitOfWork unitOfWork)
    {
        _holidayRepository = holidayRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteHolidayCommand request, CancellationToken cancellationToken)
    {
        var holidays = await _holidayRepository.GetManyAsync(request.Ids);

        if (holidays is null)
            return Errors.CouldNotFind(nameof(Holiday), request.Ids);

        _holidayRepository.DeleteRange(holidays);
        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}