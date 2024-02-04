using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;
using AugustaGourmet.Api.Domain.Entities.InventoryHandling;
using AugustaGourmet.Api.Domain.Errors;

using AutoMapper;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Receipts.GetMappedReceiptProducts;

public class GetMappedReceiptProductsQueryHandler : IRequestHandler<GetMappedReceiptProductsQuery, ErrorOr<ReceiptMappingDto>>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IMapper _mapper;

    public GetMappedReceiptProductsQueryHandler(IReceiptRepository receiptRepository, IMapper mapper)
    {
        _receiptRepository = receiptRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ReceiptMappingDto>> Handle(GetMappedReceiptProductsQuery request, CancellationToken cancellationToken)
    {
        var receipt = await _receiptRepository.GetByIdAsync(request.ReceiptId);
        if (receipt is null)
            return Errors.CouldNotFind(nameof(Receipt), request.ReceiptId);

        var mappedProducts = await _receiptRepository.GetMappedReceiptProductsAsync(request.ReceiptId);

        if (mappedProducts is null)
            return Errors.CouldNotFind(nameof(PartnerProduct), request.ReceiptId);

        return new ReceiptMappingDto
        {
            Id = receipt.Id,
            Mappings = _mapper.Map<List<ReceiptProductMappingDto>>(mappedProducts)
        };
    }
}