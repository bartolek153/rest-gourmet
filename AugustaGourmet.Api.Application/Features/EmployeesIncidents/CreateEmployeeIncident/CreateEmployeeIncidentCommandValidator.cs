using FluentValidation;

namespace AugustaGourmet.Api.Application.Features.EmployeesIncidents.CreateEmployeeIncident;

public class CreateEmployeeIncidentCommandValidator : AbstractValidator<CreateEmployeeIncidentCommand>
{
    public CreateEmployeeIncidentCommandValidator()
    {
        RuleFor(p => p.EmployeeId)
            .GreaterThan(0).WithMessage(Constants.Messages.InvalidEmployeeId);

        RuleFor(p => p.ReasonId)
            .GreaterThan(0).WithMessage(Constants.Messages.InvalidReasonId);
    }
}