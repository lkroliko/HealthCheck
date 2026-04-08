<h1 align="center">HealthChecks.Container.Client</h1>

<p align="center">
  <a href="https://www.nuget.org/packages/MrRabbit.HealthChecks.Container.Client/">
    <a href="https://dotnet.microsoft.com/"><img src="https://img.shields.io/badge/.NET-10-512bd4?logo=dotnet" alt=".NET 10"></a>
    <img src="https://img.shields.io/nuget/v/MrRabbit.HealthChecks.Container.Client" alt="NuGet" />
    <a href="https://opensource.org/licenses/MIT"><img src="https://img.shields.io/badge/License-MIT-blue.svg" alt="License: MIT"></a>
  </a>
</p>

<p align="center">
  Lightweight health check client for .NET containerized applications — no <code>curl</code> needed.
</p>

## 🔍 Problem

In newer versions of Microsoft container images (including **chiseled** variants), you can't simply install `curl` to check the status of your app. So how do you run health checks?

## ✅ Solution

### 1. Install the NuGet package

```bash
dotnet add package MrRabbit.HealthChecks.Container.Client
```

### 2. Configure `docker-compose.yml`

```yaml
healthcheck:
  test: ["CMD", "dotnet", "/[PATH TO YOUR APP]/healthcheck.dll", "ADDRESS TO HEALTH CHECK ENDPOINT"]
```

**Example:**

```yaml
healthcheck:
  test: ["CMD", "dotnet", "/app/healthcheck.dll", "http://localhost:8080/hc"]
```

> 💡 Works with **chiseled** container images too!

## 🔧 How it works

The NuGet package adds content files that are copied to the build output directory:

```
healthcheck.dll
healthcheck.runtimeconfig.json
```

You can also run it manually from a terminal inside the container:

```bash
dotnet ./healthcheck.dll http://localhost:8080/hc
```

## 📖 Sample

➡️ [Sample web app](https://github.com/lkroliko/HealthCheck/blob/master/docs/SAMPLE.md)

## 📋 Changelog

| Version | Changes |
|---------|---------|
| **10.0.0** | Added support for .NET 10 |
| **9.0.1** | Removed `linux-x64` runtime compilation for Any CPU support |
| **9.0.0** | Added support for .NET 9 |
| **8.0.0** | First release |