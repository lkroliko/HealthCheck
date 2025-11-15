using System.Reflection;

namespace HealthCheck.EndToEndTests.Common.Attributes;

public class TargetFrameworksAttribute : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod) => 
        Enum.GetValues<TargetFramework>().Select(x => new object[] { x });
}
