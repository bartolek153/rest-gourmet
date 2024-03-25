using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Employees;
using AugustaGourmet.Api.Domain.Errors;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.EmployeesIncidents.CreateEmployeeIncident;

public class CreateEmployeeIncidentCommandHandler : IRequestHandler<CreateEmployeeIncidentCommand, ErrorOr<int>>
{
    private readonly IEmployeeIncidentRepository _employeeIncidentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEmployeeIncidentCommandHandler(IEmployeeIncidentRepository employeeIncidentRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _employeeIncidentRepository = employeeIncidentRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<int>> Handle(CreateEmployeeIncidentCommand request, CancellationToken cancellationToken)
    {
        if (!request.ToDate.HasValue)
            request.ToDate = request.FromDate;

        if (!await _employeeIncidentRepository.IsUniqueAsync(request.EmployeeId, request.FromDate, request.ToDate.Value))
            return Errors.EmployeesIncidents.Conflicts.OverlappingSchedules;

        var employeeIncident = _mapper.Map<EmployeeIncidentLog>(request);
        var result = _employeeIncidentRepository.Create(employeeIncident);

        await _unitOfWork.CommitAsync();

        return result.Id;
    }
}