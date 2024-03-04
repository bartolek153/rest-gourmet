using AugustaGourmet.Api.Application.Contracts.Services;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Receipts.ImportReceiptsFromEmail;

public class ImportReceiptsFromEmailCommandHandler : IRequestHandler<ImportReceiptsFromEmailCommand, ErrorOr<int>>
{
    private readonly IReceiptService _receiptsService;

    public ImportReceiptsFromEmailCommandHandler(IReceiptService receiptsService)
    {
        _receiptsService = receiptsService;
    }

    public async Task<ErrorOr<int>> Handle(ImportReceiptsFromEmailCommand request, CancellationToken cancellationToken)
    {
        // Get the last 10 days emails
        return await _receiptsService.IntegrateReceiptsFromEmailAsync(request.FromDate);
    }
}