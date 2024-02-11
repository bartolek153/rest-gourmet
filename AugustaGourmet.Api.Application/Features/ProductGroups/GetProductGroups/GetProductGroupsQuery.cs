using AugustaGourmet.Api.Application.DTOs.Products;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductGroups.GetProductGroups;

public record GetProductGroupsQuery : IRequest<List<ProductGroupDto>>;