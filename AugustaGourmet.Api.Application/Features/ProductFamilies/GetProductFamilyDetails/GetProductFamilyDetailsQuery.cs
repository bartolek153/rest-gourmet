using AugustaGourmet.Api.Application.DTOs.Products;

using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductFamilies.GetProductFamilyDetails;

public record GetProductFamilyDetailsQuery(int Id) : IRequest<ErrorOr<ProductFamilyDto>>;