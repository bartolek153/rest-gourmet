using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Receipts.ImportReceiptsFromEmail;

public class ImportReceiptsFromEmailCommand : IRequest<ErrorOr<Unit>>
{
}