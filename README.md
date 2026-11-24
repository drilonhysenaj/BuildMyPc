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
- Frontend: React (Vite)
- Backend: ASP.NET Core Web API (.NET 10) + Swagger
- Databaza: SQL Server (Docker) + EF Core
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

Herëve tjera, në një terminal Ubuntu që mbetet i hapur:

```bash
docker start buildmypc_sqlserver
```

### 2. Backend-i

```bash
cd backend/BuildMyPcApi
dotnet ef database update
dotnet run
```

API: http://localhost:5126 — Swagger: http://localhost:5126/swagger

### 3. Frontend-i

```bash
cd frontend
npm install
npm run dev
```

Faqja: http://localhost:5173

## Përparimi
- [x] Hapi 1 — Planifikimi dhe GitHub
- [x] Hapi 2 — Produkti i parë në ekran
- [ ] Hapi 3 — Login, signup dhe JWT
- [ ] Hapi 4 — Paneli Admin
- [ ] Hapi 5 — Ndërtuesi i PC-së dhe përputhshmëria
- [ ] Hapi 6 — Porositë dhe stoku
- [ ] Hapi 7 — Docker Compose