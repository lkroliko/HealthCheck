// Ignore Spelling: App

namespace HealthCheck.EndToEndTests.Common;
public abstract class TestBase : IAsyncLifetime
{
    internal protected TestContainer Container { get; } = new();
    internal protected TestApp App { get; }

    public TestBase()
    {
        App = new(Container);
    }

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Container.StopAsync();
}
