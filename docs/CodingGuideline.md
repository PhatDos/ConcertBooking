# Coding Guideline

## Architecture

The project follows a simplified Modular Monolith architecture.

```
Modules
 ├── Booking
 ├── Concert
 ├── Payment
 └── Voucher
```

Each module contains:

- Application
- Domain
- Presentation

Infrastructure contains:

- EF Core
- DbContext
- Entity Configurations

---

## Naming Convention

Classes

- PascalCase

Methods

- PascalCase

Private fields

- _camelCase

Properties

- PascalCase

DTO

- CreateBookingRequest
- UpdateBookingStatusRequest

Configurations

- BookingConfiguration
- ConcertConfiguration

---

## Domain Rules

Business rules should stay inside Domain Entities whenever possible.

Example:

- Reserve tickets
- Confirm reservation
- Redeem voucher

Controllers only orchestrate requests.

---

## Error Handling

Business validation returns HTTP 400.

Examples:

- Not enough tickets
- Invalid concert time
- Voucher expired
- Voucher out of stock

Entity exceptions are translated into BadRequest responses in controllers.

---

## Persistence

Entity Framework Core

SQL Server

Optimistic concurrency using RowVersion for TicketCategory.

---

## API Documentation

Swagger is enabled in Development.

All APIs are documented automatically through ASP.NET Core.