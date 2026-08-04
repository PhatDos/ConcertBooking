# How To Run

## Prerequisites

- .NET 8 SDK
- SQL Server
- Visual Studio 2022 or Visual Studio Code

---

## 1. Clone repository

```bash
git clone <repository-url>
```

```bash
cd ConcertBooking
```

---

## 2. Configure database

Update **appsettings.json**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<YOUR_SQL_SERVER>;Database=ConcertBookingDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=ConcertBookingDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

---

## 3. Restore packages

```bash
dotnet restore
```

---

## 4. Apply database migrations

Navigate to the API project.

```bash
cd src/ConcertBooking.Api
```

Run

```bash
dotnet ef database update
```

---

## 5. Run the application

```bash
dotnet run
```

The application starts on

```
https://localhost:7069
```

---

## 6. Swagger

Open

```
https://localhost:7069/swagger
```

---

## 7. API Testing

The project provides

- Swagger UI
- Postman Collection

```
docs/postman/ConcertBooking.postman_collection.json
```

---

## Technology Stack

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Swagger