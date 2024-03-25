using AugustaGourmet.Api.Application.Contracts.Common;
using AugustaGourmet.Api.Application.Contracts.Persistence;

using AutoMapper;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.Suppliers.GetSuppliersQuery;

public class GetSuppliersQueryHandler : IRequestHandler<GetSuppliersQuery, PagedList<SupplierDto>>
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public GetSuppliersQueryHandler(ISupplierRepository supplierRepository, IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<SupplierDto>> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
    {
        var suppliers = await _supplierRepository.GetAllWithPaginationAsync(
            filter: request.Name is not null ? s => s.Name.ToLower().Contains(request.Name) : null,
            orderBy: i => i.OrderBy(i => i.Name),
            startPage: request.Page,
            perPage: request.PageSize,
            includeProperties: "Status");

        return new PagedList<SupplierDto>(
            _mapper.Map<List<SupplierDto>>(suppliers.Items),
            suppliers.TotalCount,
            suppliers.Page,
            suppliers.PageSize);
    }
}