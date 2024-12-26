FROM mcr.microsoft.com/dotnet/aspnet:9.0-noble-chiseled-extra AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0-noble AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApplicationSample.csproj", "."]
RUN dotnet restore "./WebApplicationSample.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./WebApplicationSample.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApplicationSample.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApplicationSample.dll"]