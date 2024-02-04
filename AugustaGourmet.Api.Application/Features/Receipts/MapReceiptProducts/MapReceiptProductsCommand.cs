using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Receipts.MapReceiptProducts;

public class MapReceiptProductsCommand : IRequest<ErrorOr<Unit>>
{
    public int Id { get; set; }
    public List<ReceiptProductMappingDto> Mappings { get; set; } = null!;
}