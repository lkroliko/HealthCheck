namespace HealthCheck.Services.Logger;

internal class NullLoger : ILogger
{
    public void LogInformation(string message, params object[] args) { }

    public void LogWarning(string message, params object[] args) { }
}
