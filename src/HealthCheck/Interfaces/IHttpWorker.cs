namespace HealthCheck.Interfaces;

internal interface IHttpWorker
{
    Task<Result> GetResultAsync(string requestUri);
}