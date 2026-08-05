namespace ConcertBooking.Api.Modules.Concert.Application.DTOs;

public sealed record TicketCategoryResponse(
    Guid Id,
    string Name,
    decimal Price,
    int TotalQuantity,
    int ReservedQuantity,
    int SoldQuantity,
    int AvailableQuantity
);