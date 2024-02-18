using AugustaGourmet.Api.Application;
using AugustaGourmet.Api.Infrastructure;
using AugustaGourmet.Api.Persistence;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices((builder, services) =>
    {
        services.AddApplicationServices();
        services.AddInfrastructureServices(builder.Configuration);
        services.AddPersistenceServices(builder.Configuration);

        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();