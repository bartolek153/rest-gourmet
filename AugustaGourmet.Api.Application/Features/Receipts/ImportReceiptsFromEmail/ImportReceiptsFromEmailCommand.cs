using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Receipts.ImportReceiptsFromEmail;

public class ImportReceiptsFromEmailCommand : IRequest<ErrorOr<int>>
{
    public DateTime FromDate { get; set; }

    public ImportReceiptsFromEmailCommand(DateTime fromDate)
    {
        FromDate = fromDate;
    }
}