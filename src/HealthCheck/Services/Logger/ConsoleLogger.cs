namespace HealthCheck.Services.Logger;

internal class ConsoleLogger : ILogger
{
    public void LogInformation(string message, params object[] args) =>
        Console.WriteLine($"[INF] - {message}", args);

    public void LogWarning(string message, params object[] args) =>
        Console.WriteLine($"[WAR] - {message}", args);
}