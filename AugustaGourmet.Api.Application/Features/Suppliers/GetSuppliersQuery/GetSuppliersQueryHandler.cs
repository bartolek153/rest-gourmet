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
        var suppliers = await _supplierRepository.GetAllFilteredAsync(
            request.Name is not null ? s => s.Name.ToLower().Contains(request.Name) : null,
            i => i.OrderBy(i => i.Name),
            request.Page,
            request.PageSize);

        return new PagedList<SupplierDto>(
            _mapper.Map<List<SupplierDto>>(suppliers.Items),
            suppliers.TotalCount,
            request.Page,
            request.PageSize);
    }
}