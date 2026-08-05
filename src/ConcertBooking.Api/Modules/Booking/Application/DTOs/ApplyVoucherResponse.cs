namespace ConcertBooking.Api.Modules.Booking.Application.DTOs;

public sealed record ApplyVoucherResponse(
    Guid Id,
    decimal DiscountAmount,
    decimal FinalAmount
);