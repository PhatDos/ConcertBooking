using ConcertBooking.Api.Modules.Booking.Domain.Enums;

namespace ConcertBooking.Api.Modules.Booking.Application.DTOs.Responses;

public sealed record BookingSummaryResponse(
    Guid Id,
    Guid UserId,
    Guid ConcertId,
    BookingStatus Status,
    decimal SubTotal,
    decimal DiscountAmount,
    decimal FinalAmount,
    DateTime ExpiresAt
);