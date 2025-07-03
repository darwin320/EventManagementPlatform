# Event Management Platform – Full Stack

* **Backend:** ASP.NET Core 8 Minimal API + EF Core SQLite  
* **Frontend:** Angular 17 SPA (shipped as a zip to keep the repo light)

---

## 1 · Prerequisites

| Tool | Version | Link |
|------|---------|------|
| **.NET SDK** | 8.0 LTS | <https://dotnet.microsoft.com/download> |
| **EF Core CLI** (only if you need extra migrations) | 8.x | `dotnet tool install --global dotnet-ef` |
| **Node.js** | 18 LTS or newer | <https://nodejs.org> |
| **Angular CLI** | ≥ 17 | `npm i -g @angular/cli` |
| *(Optional)* SQLite Browser | – | <https://sqlitebrowser.org/> |

---

## 2 · Run the Backend API

```bash
# 1 – restore NuGet packages
cd backend/Event\ Management\ Platform
dotnet restore

# 2 – create & seed the SQLite database (first run only)
dotnet ef database update

# 3 – run the API
dotnet run
# → API listens on http://localhost:5000  (Swagger available at /swagger)
```
## 2 · Run the Front-End SPA
The Angular source is compressed as Frontend/event-management-ui.zip.
Unzip once, install dependencies, and start the dev-server: 
# 1 – unzip  (one-time)
cd Frontend
# PowerShell
Expand-Archive .\event-management-ui.zip -DestinationPath .
# macOS / Linux
  unzip ./event-management-ui.zip

# 2 – install dependencies
cd event-management-ui
npm install

# 3 – start dev-server
ng serve --open
# → Browser opens http://localhost:4200   (calls the API on :5000)
Note: src/environments/environment.ts already points to
apiUrl: 'http://localhost:7198'. Change only if you run the API on another port.
