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

using WhatsappBusiness.CloudApi.Configurations;
using WhatsappBusiness.CloudApi.Extensions;

namespace AugustaGourmet.Api.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Email
        services.Configure<EmailSettings>(configuration.GetSection(EmailSettings.SectionName));
        services.AddTransient<IEmailReader, EmailReader>();

        // Telegram
        services.Configure<TelegramSettings>(configuration.GetSection(TelegramSettings.SectionName));
        services.AddTransient<ITelegramMessageSender, TelegramMessageSender>();

        // Whatsapp
        WhatsappSettings wppSett = configuration.GetSection(WhatsappSettings.SectionName).Get<WhatsappSettings>()!;
        services.AddTransient<IWhatsappMessageSender, WhatsappMessageSender>();
        services.AddWhatsAppBusinessCloudApiService(new WhatsAppBusinessCloudApiConfig
        {
            WhatsAppBusinessPhoneNumberId = wppSett.PhoneNumberId,
            WhatsAppBusinessAccountId = wppSett.BusinessAccountId,
            WhatsAppBusinessId = wppSett.BusinessId,
            AccessToken = wppSett.AccessToken
        });
        services.Configure<WhatsappSettings>(configuration.GetSection(WhatsappSettings.SectionName));

        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}