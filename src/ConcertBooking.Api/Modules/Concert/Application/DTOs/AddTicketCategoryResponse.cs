namespace ConcertBooking.Api.Modules.Concert.Application.DTOs;

public sealed record AddTicketCategoryResponse(
    Guid Id,
    string Name,
    decimal Price,
    int TotalQuantity
);