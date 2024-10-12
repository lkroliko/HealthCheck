### Build nuget

Edit nuspec change version

dotnet build -c Release -r linux-x64 -p:AssemblyName=healthcheck,Version=8.0.0,Configuration=Release --self-contained false

dotnet pack 