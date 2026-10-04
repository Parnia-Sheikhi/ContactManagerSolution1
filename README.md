# ContactManager

A web application for managing contacts, built with ASP.NET Core MVC on .NET 6. It keeps a list of people along with their country, and supports searching, sorting, and exporting the data. Access is protected by user accounts with separate user and admin roles.

## Features

- Create, edit, view and delete people, each linked to a country
- Search by any field and sort the list in ascending or descending order
- Export the list to PDF, CSV or Excel
- Import countries in bulk from an Excel file
- Registration and login with ASP.NET Core Identity
- Role-based access with a separate Admin area
- Logging with Serilog to the console, rolling files, SQL Server and Seq
- Global error handling through custom middleware

## Architecture

The solution is split into three projects:

```
ContactManager.Core            Entities, DTOs, service and repository contracts, services
ContactManager.Infrastructure  DbContext, repositories, EF Core migrations
ContactManager.UI1             Controllers, views, filters, middleware
```

Services depend only on repository interfaces, and the UI project wires everything together through dependency injection. The MVC pipeline uses custom action, result, resource, exception and authorization filters for things like logging, response headers and token checks.

## Tech stack

- .NET 6, ASP.NET Core MVC
- Entity Framework Core 6 with SQL Server
- ASP.NET Core Identity
- Serilog
- Rotativa for PDF, CsvHelper for CSV, EPPlus for Excel

## Getting started

Requires the .NET 6 SDK and SQL Server (LocalDB works).


git clone https://github.com/Parnia-Sheikhi/ContactManagerSolution1.git
dotnet ef database update --project ContactManager.Infrastructure --startup-project ContactManager.UI1
dotnet run --project ContactManager.UI1


## Notes

- To access the Admin area, choose the Admin user type when registering.
- Logs are also sent to a Seq server at `http://localhost:7190`; if Seq isn't running, the other sinks still work.
