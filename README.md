[![NuGet](https://img.shields.io/nuget/v/MrRabbit.HealthChecks.Container.Client)](https://www.nuget.org/packages/MrRabbit.HealthChecks.Container.Client/)

## HealthCheck

### Problem
In new versions of Microsoft container images you can't simply run command to install curl. 
So how you can check status of your app?

### Solution
Install package
```
dotnet add package MrRabbit.HealthChecks.Container.Client 
```

Edit your docker-compose.yml file
```
 healthcheck:
      test: [ "CMD", "dotnet", "/[PATH TO YOUR APP]/healthcheck.dll", "ADDRESS TO HEALTH CHECK ENDPOINT" ]
```

Example
```
 healthcheck:
      test: [ "CMD", "dotnet", "/app/healthcheck.dll", "http://localhost:8080/hc" ]
```

It works on container images chiseled version too.

### [Sample web app](https://github.com/lkroliko/HealthCheck/blob/develop/docs/SAMPLE.md)

### How it works
Nuget packages adds content files which are copy to build output directory.
```
healthcheck.dll
healthcheck.runtimeconfig
```
You can run it from terminal in container
```
dotnet ./healthcheck.dll
```

### Changelog

#### 9.0.0
- added support for .net 9

#### 8.0.0
- first release