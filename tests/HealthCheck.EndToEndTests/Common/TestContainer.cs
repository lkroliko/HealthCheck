using DotNet.Testcontainers.Builders;
using System.Diagnostics;
using System.Net;

namespace HealthCheck.EndToEndTests.Common;

public class TestContainer
{
    public ushort Port { get; } = (ushort)Random.Shared.Next(8100, IPEndPoint.MaxPort);
    private IContainer _container = default!;

    public TestcontainersHealthStatus Health => GetContainerHealth();

    public async Task StartAsync(TargetFramework framework)
    {
        _container = new ContainerBuilder()
            .WithImage($"localhost/test-container:{framework.GetName()}")
            .WithPortBinding(Port, 8080)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilContainerIsHealthy())
            .Build();

        await _container.StartAsync();
    }

    public Task StopAsync() => _container.StopAsync();

    /// <summary>
    /// IContainer.Health not refreshing status after container started
    /// </summary>
    /// <returns></returns>
    private TestcontainersHealthStatus GetContainerHealth()
    {
        var process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.Arguments = @$"/C podman container ls -f id={_container.Id}";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardInput = true;
        process.Start();

        var output = process.StandardOutput.ReadToEnd();

        if (output.Contains("unhealthy"))
            return TestcontainersHealthStatus.Unhealthy;

        if (output.Contains("healthy"))
            return TestcontainersHealthStatus.Healthy;

        return TestcontainersHealthStatus.None;
    }
}
