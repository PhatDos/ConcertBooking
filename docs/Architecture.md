# System Architecture

## Overview

The system is designed using a simplified Modular Monolith architecture.

Each business module is organized into the following layers:

- Presentation
- Application
- Domain

Infrastructure components are shared across all modules.

```
Client
      │
 HTTP REST API
      │
 ASP.NET Core
      │
────────────────────────
│       Modules        │
────────────────────────
│ Concert             │
│ Booking             │
│ Voucher             │
│ Payment             │
────────────────────────
      │
Entity Framework Core
      │
 SQL Server
```

---

## Aggregate Roots

Each business module exposes a single Aggregate Root.

- Concert
  - TicketCategory

- Booking
  - BookingItem

- Voucher

- Payment

Business rules are enforced inside Aggregate Roots to maintain domain consistency.

---

## Why Modular Monolith?

This project focuses on demonstrating clean code organization rather than distributed deployment.

Advantages:

- Easy to develop and maintain
- Clear module boundaries
- Easier debugging
- Suitable for startup-scale systems
- Can be migrated to Microservices in the future

---

## Module Responsibilities

### Concert

- Manage concerts
- Manage ticket categories

### Booking

- Create bookings
- Reserve tickets
- Manage booking workflow
- Manage booking status

### Voucher

- Manage vouchers
- Calculate discounts

### Payment

- Process mock payments
- Confirm bookings after successful payment

---

## Layer Responsibilities

### Presentation

- Controllers
- HTTP endpoints

### Application

- DTOs
- Request / Response models

### Domain

- Entities
- Business rules
- Domain logic

### Infrastructure

- Entity Framework Core
- DbContext
- Entity Configurations
- SQL Server persistence

---

## Design Decisions

The project follows a simplified Modular Monolith architecture because it provides:

- Clear module separation
- Faster development during the assignment
- Easier debugging
- Better maintainability
- A migration path to Microservices if the system grows

Business logic is implemented inside Domain Entities to keep controllers thin and maintain separation of concerns.

---

# Future Improvements

This project intentionally prioritizes correctness of the booking workflow and clean architecture over feature completeness.

If more development time is available, the following improvements should be implemented:

- VoucherRedemption entity to prevent voucher abuse per user.
- BookingStatusHistory for audit logging.
- Authentication and Authorization using JWT.
- Background worker for automatic booking expiration.
- Payment gateway callback integration.
- Distributed cache (Redis).
- Message Queue for flash-sale traffic.
- Distributed locking to further reduce ticket overselling.
- Seat allocation for assigned seating concerts.