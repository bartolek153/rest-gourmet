using AugustaGourmet.Api.Application.Contracts.Emails;
using AugustaGourmet.Api.Application.Contracts.Logging;
using AugustaGourmet.Api.Application.Contracts.TextMessage;
using AugustaGourmet.Api.Application.Emails;
using AugustaGourmet.Api.Application.TextMessages;
using AugustaGourmet.Api.Infrastructure.Emails;
using AugustaGourmet.Api.Infrastructure.Logging;
using AugustaGourmet.Api.Infrastructure.TextMessages;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AugustaGourmet.Api.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailReader, EmailReader>();

        services.Configure<TelegramSettings>(configuration.GetSection("TelegramSettings"));
        services.AddTransient<ITextMessageSender, TelegramMessageSender>();

        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}