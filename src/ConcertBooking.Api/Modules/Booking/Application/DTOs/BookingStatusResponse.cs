using ConcertBooking.Api.Modules.Booking.Domain.Enums;

namespace ConcertBooking.Api.Modules.Booking.Application.DTOs;

public sealed record BookingStatusResponse(
    Guid Id,
    BookingStatus Status
);