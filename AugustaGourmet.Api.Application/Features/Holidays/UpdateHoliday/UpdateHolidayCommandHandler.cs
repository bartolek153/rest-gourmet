using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.General;
using AugustaGourmet.Api.Domain.Errors;
using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Holidays.UpdateHoliday;

public class UpdateHolidayCommandHandler : IRequestHandler<UpdateHolidayCommand, ErrorOr<Unit>>
{
    private readonly IHolidayRepository _holidayRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateHolidayCommandHandler(IHolidayRepository holidayRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _holidayRepository = holidayRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateHolidayCommand request, CancellationToken cancellationToken)
    {
        if (await _holidayRepository.IsHolidayAsync(request.Date))
            return Errors.NotUniqueDate;

        var holiday = _mapper.Map<Holiday>(request);

        holiday.CompanyId = 1; // TODO: remove hardcoded value

        _holidayRepository.Update(holiday);
        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}