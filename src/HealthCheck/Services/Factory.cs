using HealthCheck.Services.Logger;

namespace HealthCheck.Services;

internal class Factory
{
    internal static ILogger GetLogger(bool silentOption) => silentOption ? new NullLoger() : new ConsoleLogger();
    internal static IHttpWorker GetHttpWorker(ILogger logger) => new HttpWorker(logger);
}
