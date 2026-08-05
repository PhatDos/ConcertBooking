using ConcertBooking.Api.Modules.Concert.Domain.Enums;

namespace ConcertBooking.Api.Modules.Concert.Application.DTOs.Responses;

public sealed record CreateConcertResponse(
    Guid Id,
    string Name,
    ConcertStatus Status
);