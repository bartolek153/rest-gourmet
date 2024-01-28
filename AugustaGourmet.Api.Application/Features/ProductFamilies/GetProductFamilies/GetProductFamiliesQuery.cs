using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductFamilies.GetProductFamilies;

public record GetProductFamiliesQuery : IRequest<List<ProductFamilyDto>>;