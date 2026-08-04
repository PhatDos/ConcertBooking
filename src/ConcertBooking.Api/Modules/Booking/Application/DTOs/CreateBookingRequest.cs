namespace ConcertBooking.Api.Modules.Booking.Application.DTOs;

public class CreateBookingRequest
{
    public Guid UserId { get; set; }

    public Guid ConcertId { get; set; }

    public string IdempotencyKey { get; set; } = default!;

    public Guid? VoucherId { get; set; }

    public List<CreateBookingItemRequest> Items { get; set; } = [];
}