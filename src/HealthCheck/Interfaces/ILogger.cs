namespace HealthCheck.Interfaces;

internal interface ILogger
{
    void LogInformation(string message, params object[] args);
    void LogWarning(string message, params object[] args);
}