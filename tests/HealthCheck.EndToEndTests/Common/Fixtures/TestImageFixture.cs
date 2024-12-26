namespace HealthCheck.EndToEndTests.Common.Fixtures;
public class TestImageFixture : IAsyncLifetime
{
    public Task DisposeAsync() => Task.CompletedTask;
    public async Task InitializeAsync()
    {
        var testImageBuilder = new TestImageBuilder();
        foreach (var framework in Enum.GetValues<TargetFramework>())
        {
            await testImageBuilder.BuildAsync(framework);
        }
    }
}
