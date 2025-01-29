FROM mcr.microsoft.com/dotnet/aspnet:8.0-noble-chiseled-extra AS base
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
HEALTHCHECK --interval=1s --timeout=1s --retries=1 CMD [ "dotnet", "/app/healthcheck.dll", "http://localhost:8080/hc" ]
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0-noble AS build
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY . .
RUN dotnet nuget add source /src --name local
RUN dotnet restore "./TestContainer.Net8.csproj"
RUN dotnet build "./TestContainer.Net8.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TestContainer.Net8.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
RUN chmod -R 755 /app/publish/appsettings.json

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestContainer.Net8.dll"]