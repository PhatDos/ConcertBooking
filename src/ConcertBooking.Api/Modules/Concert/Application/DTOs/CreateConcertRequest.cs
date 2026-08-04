namespace ConcertBooking.Api.Modules.Concert.Application.DTOs;

public class CreateConcertRequest
{
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string Venue { get; set; } = default!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }
}