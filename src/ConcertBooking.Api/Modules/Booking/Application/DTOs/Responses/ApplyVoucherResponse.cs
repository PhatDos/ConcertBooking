namespace ConcertBooking.Api.Modules.Booking.Application.DTOs.Responses;

public sealed record ApplyVoucherResponse(
    Guid Id,
    decimal DiscountAmount,
    decimal FinalAmount
);