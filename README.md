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

## Përparimi
- [x] Hapi 2 — Produkti i parë në ekran
- [ ] Hapi 3 — Katalogu
- [ ] Hapi 4 — Login dhe Admin
- [ ] Hapi 5 — Ndërtuesi i PC-së
- [ ] Hapi 6 — Konfigurimet dhe porositë
- [ ] Hapi 7 — Testet dhe Docker