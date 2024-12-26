## Sample

Go to sample\WebApplicationSample catalog.
Build image
```
podman compose build
```

Run image
```
podman compose up -d
```

Check container health status
```
podman container ls
```

Change app health status 
- http://localhost:8080/healthy - container healthy
- http://localhost:8080/degraded - container healthy
- http://localhost:8080/unhealthy - container unhealthy
