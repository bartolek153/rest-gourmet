using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Persistence.Context;
using AugustaGourmet.Api.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AugustaGourmet.Api.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")!;

        services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        services.AddScoped<IProductFamilyRepository, ProductFamilyRepository>();
        services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
        services.AddScoped<IReceiptRepository, ReceiptRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IPartnerProductRepository, PartnerProductRepository>();
        services.AddScoped<IInventoryParameterRepository, InventoryParameterRepository>();
        services.AddScoped<IUnitMeasureRepository, UnitMeasureRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IEmployeeIncidentRepository, EmployeeIncidentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}