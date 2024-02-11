using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Contracts.Services;

public interface IReceiptsService
{
    Task<ErrorOr<Unit>> IntegrateReceiptsFromEmailAsync(DateTime fromDate);
}