﻿using AugustaGourmet.Api.Domain.Entities.Products;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<bool> IsUniqueAsync(string description);
    Task<bool> AnyProductWithGroupAsync(int groupId);
    Task<IReadOnlyList<ProductOrigin>> GetProductOriginsAsync();
}