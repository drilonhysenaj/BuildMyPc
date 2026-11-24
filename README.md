# BuildMyPC — ndërto kompjuterin tënd

Aplikacion web ku përdoruesi zgjedh pjesët e kompjuterit, sistemi kontrollon
përputhshmërinë, llogarit çmimin dhe lejon ruajtjen ose porositjen.

## Përdoruesi
- Regjistrohet dhe kyçet
- Shfleton, kërkon dhe filtron pjesët
- Zgjedh CPU, motherboard, RAM, GPU, SSD, PSU dhe kasë
- Sheh çmimin total dhe paralajmërimet për mospërputhje
- Ruan konfigurimin, porosit dhe sheh statusin e porosive

## Administratori (nga paneli Admin)
- Shton, ndryshon dhe çaktivizon pjesë (çmimi, fotoja, specifikat, stoku)
- Menaxhon porositë dhe statuset e tyre

## Teknologjitë
- Frontend: React
- Backend: ASP.NET Core Web API (.NET 10)
- Databaza: SQL Server + EF Core
- Siguria: JWT + role (User, Admin)
- Ambienti: Docker Compose

## Si ta nisësh projektin lokalisht

### 1. Databaza (SQL Server në Docker)

Krijimi i kontejnerit, vetëm herën e parë (në Ubuntu/WSL):

```bash
docker run -d \
  --name buildmypc_sqlserver \
  -e "ACCEPT_EULA=Y" \
  -e "MSSQL_SA_PASSWORD=BuildMyPc123." \
  -e "MSSQL_PID=Developer" \
  -p 1436:1433 \
  -v buildmypc_sqlserver_data:/var/opt/mssql \
  mcr.microsoft.com/mssql/server:2022-latest
```

Nisja dhe ndalja, herëve tjera (nga PowerShell):

```bash
wsl -d Ubuntu docker start buildmypc_sqlserver
wsl -d Ubuntu docker stop buildmypc_sqlserver
```

### 2. Backend-i

```bash
cd backend/BuildMyPcApi
dotnet run
```

Swagger: http://localhost:5126/swagger

## Përparimi
- [x] Hapi 2 — Produkti i parë në ekran
- [ ] Hapi 3 — Katalogu
- [ ] Hapi 4 — Login dhe Admin
- [ ] Hapi 5 — Ndërtuesi i PC-së
- [ ] Hapi 6 — Konfigurimet dhe porositë
- [ ] Hapi 7 — Testet dhe Docker