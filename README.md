# Concert Booking Platform

Backend assignment for Concert Ticket Booking Platform.

## Tech Stack

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Swagger
- Modular Monolith Architecture

---

# Features

## Customer APIs

- Browse concerts
- View ticket categories
- Create booking
- Apply voucher
- Process payment
- Track booking status

## Operation APIs

- Create concert
- Add ticket category
- Create voucher
- Update booking status

---

# Project Structure

src/
    ConcertBooking.Api/
        Modules/
            Booking/
            Concert/
            Payment/
            Voucher/
            User/
        Infrastructure/
        Shared/

---

# Architecture

Modular Monolith

Presentation

↓

Application

↓

Domain

↓

Infrastructure

↓

SQL Server

---

# Run

dotnet restore

dotnet ef database update

dotnet run

Swagger

https://localhost:7069/swagger

---

# Documents

docs/

- Architecture.md
- DatabaseDesign.md
- Assumptions.md
- Limitations.md
- CodingGuideline.md
