
using System.Reflection;

using AugustaGourmet.Api.Application.Behaviors;
using AugustaGourmet.Api.Application.Contracts.Services;
using AugustaGourmet.Api.Application.Services;

using FluentValidation;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace AugustaGourmet.Api.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IReceiptService, ReceiptService>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}