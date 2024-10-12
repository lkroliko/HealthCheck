using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebApplicationSample;

public class TestHealthCheck : IHealthCheck
{
    public static HealthStatus Status { get; set; } = HealthStatus.Healthy;

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default) => TestHealthCheck.Status switch
    {
        HealthStatus.Healthy => Task.FromResult(HealthCheckResult.Healthy(GetDecription())),
        HealthStatus.Degraded => Task.FromResult(HealthCheckResult.Degraded(GetDecription())),
        HealthStatus.Unhealthy => Task.FromResult(HealthCheckResult.Unhealthy(GetDecription())),
        _ => throw new NotImplementedException(),
    };

    private string GetDecription() => $"Status is '{Status}'.";
}
