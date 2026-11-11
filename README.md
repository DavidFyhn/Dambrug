# Dambrug

Dambrug is a fish farm management project for tracking ponds, fish counts, biomass, growth and feeding.

## Project structure

- `Client/` contains the React and TypeScript app built with Vite.
- `Server/Api/` contains the ASP.NET Core Web API.
- `Server/DataAccess/` is the PostgreSQL data access project.
- `Server/Tests/` contains xUnit tests for the server.

## Local development

Install the .NET 9 SDK and Node.js 22.12 or later. Open two terminals at the repository root.

Start the API on port 5211.

```sh
dotnet run --project Server/Api
```

Start the client on port 5173.

```sh
cd Client
npm install
npm run dev
```

Open http://localhost:5173. Vite proxies `/api` to the API, and the client shows whether it can reach `/api/health`.

When you need a PostgreSQL connection, set `ConnectionStrings__Dambrug` in the API process environment. The API registers an Npgsql data source when that setting is present. The data access project is ready for persistence code. Add EF Core scaffolding after you have a database schema if you follow that part of the tutorial. The health endpoint checks the API process and runs without a database.

Run server tests with `dotnet test Server/Server.sln`. Build the client with `npm run build` from `Client/`.

