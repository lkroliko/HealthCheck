using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using WebApplicationSample;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddHealthChecks().AddCheck<TestHealthCheck>("Example", HealthStatus.Unhealthy);
builder.Services.AddHealthChecksUI(options =>
{
    options.AddHealthCheckEndpoint("Positano server", $"{builder.Configuration["BaseAddress"]}/hc");
    options.SetEvaluationTimeInSeconds(10);
    options.MaximumHistoryEntriesPerEndpoint(60);
}).AddInMemoryStorage();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapGet("/healthy", () =>
{
    TestHealthCheck.Status = HealthStatus.Healthy;
    return $"Status changed to '{TestHealthCheck.Status}'.";
});
app.MapGet("/degraded", () =>
{
    TestHealthCheck.Status = HealthStatus.Degraded;
    return $"Status changed to '{TestHealthCheck.Status}'.";
});
app.MapGet("/unhealthy", () =>
{
    TestHealthCheck.Status = HealthStatus.Unhealthy;
    return $"Status changed to '{TestHealthCheck.Status}'.";
});

app.MapHealthChecks("/healthz");
app.UseHealthChecks("/hc", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseHealthChecksUI(options =>
{
    options.UIPath = "/hc-ui";
    options.UseRelativeResourcesPath = true;
});
app.Run();
