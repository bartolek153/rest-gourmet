using ErrorOr;

namespace AugustaGourmet.Api.Application.Contracts.Services;

public interface IReceiptService
{
    Task<ErrorOr<int>> IntegrateReceiptsFromEmailAsync();
    Task<ErrorOr<int>> IntegrateReceiptsFromEmailAsync(DateTime fromDate);
}