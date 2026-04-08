## 📖 Sample

### 1. Go to sample directory

```bash
cd sample/WebApplicationSample
```

### 2. Build image

```bash
podman compose build
```

### 3. Run image

```bash
podman compose up -d
```

### 4. Check container health status

```bash
podman container ls
```

### 5. Change app health status

| Endpoint | Health Status |
|----------|---------------|
| `http://localhost:8080/healthy` | ✅ container healthy |
| `http://localhost:8080/degraded` | ⚠️ container healthy |
| `http://localhost:8080/unhealthy` | ❌ container unhealthy |
