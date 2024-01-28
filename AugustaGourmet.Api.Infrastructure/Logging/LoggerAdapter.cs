
using AugustaGourmet.Api.Application.Contracts.Logging;

using Microsoft.Extensions.Logging;

namespace AugustaGourmet.Api.Infrastructure.Logging;

public class LoggerAdapter<T> : IAppLogger<T>
{
    private readonly ILogger<T> _logger;

    public LoggerAdapter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<T>();
    }

    public void LogCritical(string message, params object[] args)
    {
        _logger.LogCritical(message, args);
    }

    public void LogError(string message, params object[] args)
    {
        _logger.LogError(message, args);
    }

    public void LogError(Exception ex)
    {
        string message =
            $"Error: {ex.Message}\n" +
            (ex.InnerException?.Message != null ? $"Inner Details: {ex.InnerException?.Message}\n" : "") +
            $"Source: {ex.Source}\n";

        _logger.LogError(message);
    }

    public void LogInformation(string message, params object[] args)
    {
        _logger.LogInformation(message, args);
    }

    public void LogWarning(string message, params object[] args)
    {
        _logger.LogWarning(message, args);
    }
}