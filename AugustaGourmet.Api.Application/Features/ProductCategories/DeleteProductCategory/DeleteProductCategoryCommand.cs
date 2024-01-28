using ErrorOr;

using MediatR;

namespace AugustaGourmet.Api.Application.Features.ProductCategories.DeleteProductCategory;

public record DeleteProductCategoryCommand(int Id) : IRequest<ErrorOr<Unit>>;