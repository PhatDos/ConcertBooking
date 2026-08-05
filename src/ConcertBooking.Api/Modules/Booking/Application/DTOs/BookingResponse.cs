using ConcertBooking.Api.Modules.Booking.Domain.Enums;

namespace ConcertBooking.Api.Modules.Booking.Application.DTOs;

public sealed record BookingResponse(
    Guid Id,
    BookingStatus Status,
    decimal SubTotal,
    decimal DiscountAmount,
    decimal FinalAmount,
    DateTime ExpiresAt,
    IReadOnlyCollection<BookingItemResponse> Items
);