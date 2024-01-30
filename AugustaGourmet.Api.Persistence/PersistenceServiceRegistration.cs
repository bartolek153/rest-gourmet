using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Persistence.Context;
using AugustaGourmet.Api.Persistence.Repositories;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AugustaGourmet.Api.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ApplicationContext>(_ =>
                new ApplicationContext(configuration.GetConnectionString("DefaultConnection")!));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        services.AddScoped<IProductFamilyRepository, ProductFamilyRepository>();
        services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();

        return services;
    }
}