
namespace AugustaGourmet.Api.Application.Contracts.Logging;

public interface IAppLogger<T>
{
    void LogCritical(string message, params object[] args);
    void LogError(string message, params object[] args);
    void LogError(Exception ex, string message);
    void LogInformation(string message, params object[] args);
    void LogWarning(string message, params object[] args);
}