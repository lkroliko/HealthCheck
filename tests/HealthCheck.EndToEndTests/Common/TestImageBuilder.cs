using DotNet.Testcontainers.Builders;

namespace HealthCheck.EndToEndTests.Common;
internal class TestImageBuilder
{
    public async Task BuildAsync(TargetFramework framework)
    {
        var image = new ImageFromDockerfileBuilder()
          .WithDockerfileDirectory(CommonDirectoryPath.GetSolutionDirectory(), $"tests\\TestContainer.{framework.GetName()}")
          .WithName($"localhost/test-container:{framework.GetName().ToLower()}")
          .WithDockerfile("Dockerfile")
          .Build();

        await image.CreateAsync();
    }
}
