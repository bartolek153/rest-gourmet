using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.General;
using AugustaGourmet.Api.Domain.Errors;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Holidays.CreateHoliday;

public class CreateHolidayCommandHandler : IRequestHandler<CreateHolidayCommand, ErrorOr<int>>
{
    private readonly IHolidayRepository _holidayRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateHolidayCommandHandler(IHolidayRepository holidayRepository, IUnitOfWork unitOfWork)
    {
        _holidayRepository = holidayRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<int>> Handle(CreateHolidayCommand request, CancellationToken cancellationToken)
    {
        if (await _holidayRepository.IsHolidayAsync(request.Date))
            return Errors.NotUniqueDate;

        var holiday = new Holiday
        {
            Description = request.Description,
            Date = request.Date,
            CompanyId = 1 // TODO: remove hardcoded value
        };

        _holidayRepository.Create(holiday);
        await _unitOfWork.CommitAsync();

        return holiday.Id;
    }
}