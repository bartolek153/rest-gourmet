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
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (connectionString is null)
            connectionString = Environment.GetEnvironmentVariable("CONNSTR");

        if (connectionString is null)
            throw new ArgumentNullException("Could not find connection string.");

        services.AddScoped<ApplicationContext>(_ =>
                new ApplicationContext(connectionString));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        services.AddScoped<IProductFamilyRepository, ProductFamilyRepository>();
        services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
        services.AddScoped<IInvoiceRepository, ReceiptRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IPartnerProductRepository, PartnerProductRepository>();

        return services;
    }
}