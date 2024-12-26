namespace HealthCheck.EndToEndTests.Common.Extensions;
public static class Extensions
{
    /// <param name="framework"></param>
    /// <returns>e.g. net8</returns>
    public static string GetName(this TargetFramework framework) => framework.ToString().Replace("Dot", "").ToLower();
}
