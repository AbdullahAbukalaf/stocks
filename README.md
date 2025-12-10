# Stocks API

Lightweight .NET8 Web API for managing stocks. This repository contains the `api` project which exposes endpoints to create, read, update and delete stock resources.

## Prerequisites

- .NET8 SDK
- (Optional) A SQL Server or other supported database when using EF Core in production

## Quick start

1. Open a terminal and navigate to the repo root:

 ```bash
 cd api
 ```

2. Restore packages and build:

 ```bash
 dotnet restore
 dotnet build
 ```

3. Run the API:

 ```bash
 dotnet run
 ```

By default the application reads configuration from `appsettings.json` in the `api` project. Update connection strings or other settings there or use environment variables.

## Endpoints (example)

The API exposes a `StockController` with typical REST endpoints under `/api/stocks`:

- `GET /api/stocks` — list stocks
- `GET /api/stocks/{id}` — get a stock by id
- `POST /api/stocks` — create a stock
- `PUT /api/stocks/{id}` — update a stock
- `DELETE /api/stocks/{id}` — delete a stock

Refer to the controller and DTOs for request/response shapes.

## Project layout

- `Controllers/` - API controllers
- `Repositories/` - data access implementations
- `DTO/` - Data Transfer Objects
- `Mapper/` - mapping between models and DTOs
- `Validation/` - request validators
- `Data/` - EF Core configuration and `ApplicationDBContext`

## Development notes

- The project targets .NET8. Use the .NET8 SDK when building or running.
- Validation is implemented with request validators already present in `Validation/`.
- If you add EF Core migrations, run them from the `api` project directory.

## Contributing

File an issue or open a pull request with a clear description of the change.

