using ConcertBooking.Api.Modules.Booking.Domain.Enums;

namespace ConcertBooking.Api.Modules.Booking.Application.DTOs.Responses;

public sealed record CreateBookingResponse(
    Guid Id,
    BookingStatus Status,
    decimal SubTotal,
    decimal DiscountAmount,
    decimal FinalAmount,
    DateTime ExpiresAt
);