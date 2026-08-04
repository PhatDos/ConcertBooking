# System Architecture

## Overview

The system is designed using a simplified Modular Monolith architecture.

Each business module is organized into:

- Presentation
- Application
- Domain

Infrastructure concerns are shared.

```
Client
      │
HTTP REST API
      │
ASP.NET Core
      │
────────────────────────
│      Modules         │
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

## Why Modular Monolith?

This project focuses on code organization instead of distributed deployment.

Advantages:

- Easy to develop
- Easy to understand
- Clear module boundaries
- Suitable for startup scale
- Can be migrated to Microservices in the future

---

## Module Responsibilities

### Concert

- Manage concerts
- Manage ticket categories

### Booking

- Reserve tickets
- Booking workflow
- Booking status

### Voucher

- Voucher management
- Discount calculation

### Payment

- Mock payment processing
- Confirm booking

---

## Layer Responsibility

### Presentation

Controllers

### Application

DTOs

### Domain

Business Rules

### Infrastructure

EF Core

Persistence

Configurations

## Design Decisions

The project follows a Modular Monolith architecture.

Reasons:

- Easy to develop within the assignment timeframe.
- Clear module boundaries.
- Easier debugging.
- Suitable for startup-scale systems.
- Can be migrated to Microservices later if necessary.

Business logic is placed inside Domain Entities to keep controllers thin and maintain separation of concerns.

# Future Improvements

If more development time is available, the following features should be implemented:

- VoucherRedemption entity to prevent voucher abuse per user.
- BookingStatusHistory for audit logging.
- Authentication & Authorization using JWT.
- Background worker for automatic booking expiration.
- Payment callback integration.
- Distributed cache (Redis).
- Message Queue for flash sale traffic.
- Distributed locking to reduce ticket overselling.
- Seat allocation for assigned seating concerts.