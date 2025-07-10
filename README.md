# Phonebook Web Application

This repository contains a sample Phonebook web application built with **.NET 9**, **Blazor WebAssembly** (client) and an ASP.NET Core minimal API (server). The project demonstrates the use of Entity Framework Core with SQL Server, AutoMapper, Serilog logging, FluentValidation, and a layered architecture with repository and service patterns.

## Project Structure

```
src/
  Client/        Blazor WebAssembly client
  Server/        ASP.NET Core server (minimal API)
  Shared/        Shared DTOs and models
  Infrastructure/ Data access and EF Core context

tests/
  UnitTests/     xUnit test project
```

## Prerequisites

- .NET SDK 9.0 (preview)
- SQL Server instance

## Running the Application

1. Ensure a SQL Server instance is running and update the connection string in `src/Server/appsettings.json`.
2. From the repository root, restore and build the solution:
   ```bash
   dotnet restore
   dotnet build
   ```
3. Apply EF Core migrations:
   ```bash
   dotnet ef database update --project src/Infrastructure --startup-project src/Server
   ```
4. Start the server and client:
   ```bash
   dotnet run --project src/Server
   ```
   The Blazor WebAssembly client will be served from the server.

## Testing

Run unit tests with:
```bash
 dotnet test
```

## Notes

This project is provided as a starting point and may require additional configuration depending on your environment. See individual project files for more details.

