using ConcertBooking.Api.Modules.Concert.Domain.Enums;

namespace ConcertBooking.Api.Modules.Concert.Application.DTOs.Responses;

public sealed record ConcertResponse(
    Guid Id,
    string Name,
    string Description,
    string Venue,
    DateTime StartTime,
    DateTime EndTime,
    ConcertStatus Status,
    IReadOnlyCollection<TicketCategoryResponse> TicketCategories);