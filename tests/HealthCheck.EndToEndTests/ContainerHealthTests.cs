// Ignore Spelling: App

namespace HealthCheck.EndToEndTests;

[Collection(nameof(TestImageCollection))]
public class ContainerHealthTests : TestBase
{
    [Theory]
    [TargetFrameworks]
    public async Task WhenContainerStartThenContainerHealthIsHealthy(TargetFramework framework)
    {
        await Container.StartAsync(framework);

        Container.Health.Should().Be(TestcontainersHealthStatus.Healthy);
    }

    [Theory]
    [TargetFrameworks]
    public async Task WhenAppHealthIsUnhealthyThenContainerHealthIsUnhealthy(TargetFramework framework)
    {
        await Container.StartAsync(framework);

        await App.SetHealthStatusAsync(HealthStatus.Unhealthy);

        Container.Health.Should().Be(TestcontainersHealthStatus.Unhealthy);
    }

    [Theory]
    [TargetFrameworks]
    public async Task WhenAppHealthIsDegradedThenContainerHealthIsHealthy(TargetFramework framework)
    {
        await Container.StartAsync(framework);

        await App.SetHealthStatusAsync(HealthStatus.Degraded);

        Container.Health.Should().Be(TestcontainersHealthStatus.Healthy);
    }
}
