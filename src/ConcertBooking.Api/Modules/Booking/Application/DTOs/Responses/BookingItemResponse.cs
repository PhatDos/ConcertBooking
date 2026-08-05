using System;

namespace ConcertBooking.Api.Modules.Booking.Application.DTOs.Responses;

public sealed record BookingItemResponse(
    Guid TicketCategoryId,
    int Quantity,
    decimal UnitPrice,
    decimal TotalPrice
);