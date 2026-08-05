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

- Presentation
- Application
- Domain

Infrastructure contains:

- Entity Framework Core
- DbContext
- Entity Configurations

---

## Naming Convention

### Classes

- PascalCase

### Methods

- PascalCase

### Properties

- PascalCase

### Private Fields

- _camelCase

### DTOs

Examples:

- CreateBookingRequest
- UpdateBookingStatusRequest
- ApplyVoucherRequest

### Entity Configurations

Examples:

- BookingConfiguration
- ConcertConfiguration
- TicketCategoryConfiguration

---

## Module Naming

Modules use singular names:

- Booking
- Concert
- Voucher
- Payment

Some modules share the same name as their Aggregate Root entity.

To avoid namespace conflicts, C# aliases are used when necessary.

Example:

```csharp
using BookingEntity = ConcertBooking.Api.Modules.Booking.Domain.Entities.Booking;
using ConcertEntity = ConcertBooking.Api.Modules.Concert.Domain.Entities.Concert;
```

---

## Domain Rules

Business rules should remain inside Domain Entities whenever possible.

Examples:

- Reserve tickets
- Confirm reservations
- Redeem vouchers
- Calculate booking totals

Controllers should only orchestrate requests and delegate business logic to the domain.

---

## Error Handling

Business validation returns **HTTP 400 Bad Request**.

Examples:

- Not enough available tickets
- Invalid concert time
- Voucher expired
- Voucher out of stock

Domain exceptions are translated into appropriate HTTP responses in controllers.

---

## Persistence

- Entity Framework Core
- SQL Server
- Optimistic concurrency using SQL Server RowVersion for TicketCategory

---

## API Documentation

Swagger is enabled in the Development environment.

All APIs are automatically documented using ASP.NET Core OpenAPI support.