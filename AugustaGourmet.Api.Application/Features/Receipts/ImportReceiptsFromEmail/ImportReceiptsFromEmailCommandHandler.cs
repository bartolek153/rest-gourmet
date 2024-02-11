using AugustaGourmet.Api.Application.Contracts.Services;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Receipts.ImportReceiptsFromEmail;

public class ImportReceiptsFromEmailCommandHandler : IRequestHandler<ImportReceiptsFromEmailCommand, ErrorOr<Unit>>
{
    private readonly IReceiptsService _receiptsService;

    public ImportReceiptsFromEmailCommandHandler(IReceiptsService receiptsService)
    {
        _receiptsService = receiptsService;
    }

    public async Task<ErrorOr<Unit>> Handle(ImportReceiptsFromEmailCommand request, CancellationToken cancellationToken)
    {
        // Get the last 10 days emails
        return await _receiptsService.IntegrateReceiptsFromEmailAsync(DateTime.Now.AddDays(-7));
    }
}