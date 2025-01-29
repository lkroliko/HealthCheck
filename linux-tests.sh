dotnet clean
dotnet build dotnet build ./tests/HealthCheck.EndToEndTests
cp ./nugets/* ./tests/TestContainer.Net8
cp ./nugets/* ./tests/TestContainer.Net9
dotnet test