using ConcertBooking.Api.Modules.Booking.Domain.Enums;

namespace ConcertBooking.Api.Modules.Payment.Application.DTOs.Responses;

public sealed record PaymentResponse(
    Guid Id,
    BookingStatus Status,
    string PaymentMethod,
    string Message
);