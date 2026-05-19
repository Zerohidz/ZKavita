# Kavita — Dev Notes

## Gereksinimler

- .NET 10 SDK (`dotnet-sdk` + `aspnet-runtime` — Arch: `sudo pacman -S dotnet-sdk aspnet-runtime`)
- Node.js 18+ (`node`, `npm`)
- Angular CLI: `npm install -g @angular/cli`

## Başlatma

**Terminal 1 — Backend:**
```bash
cd Kavita.Server
dotnet run -c Debug
# http://localhost:5000
# http://localhost:5000/swagger  (API dokümantasyon)
```

**Terminal 2 — Frontend:**
```bash
cd UI/Web
npm install        # ilk seferinde
npm run start-proxy
# http://localhost:4200
```

> `start-proxy` zorunlu. Angular (4200) ve backend (5000) farklı portta çalışır.
> `proxy.conf.json` `/api`, `/hubs`, `/oidc/*` isteklerini 5000'e yönlendirir.
> `npm run start` ile API çağrıları 404 döner.

## Database Migration

Entity değişince:
```bash
dotnet ef migrations add \
  --project Kavita.Database/Kavita.Database.csproj \
  --startup-project Kavita.Server/Kavita.Server.csproj \
  --context Kavita.Database.DataContext \
  --configuration Debug \
  --output-dir Migrations \
  MigrationAdi
```

## Proje Yapısı

```
Kavita.Server/      # ASP.NET Core — startup, controllers, middleware
Kavita.Services/    # Business logic
Kavita.Database/    # EF Core, entities, migrations
Kavita.Common/      # Shared utilities
Kavita.API/         # (wwwroot — Angular build buraya kopyalanır)
UI/Web/             # Angular frontend
```

## Branch Stratejisi

- PR hedefi: `develop` (main'e değil)
- Feature branch: `feature/aciklayici-isim`
- Bugfix branch: `bugfix/aciklayici-isim`

## Notlar

- SQLite DB varsayılan olarak `Kavita.Server/config/kavita.db` oluyor
- Log seviyesi Debug modda verbose — `[Fatal]` etiketli satırlar aslında info/migration mesajı, gerçek hata değil
