namespace ConcertBooking.Api.Modules.Booking.Application.DTOs;

public class CreateBookingItemRequest
{
    public Guid TicketCategoryId { get; set; }

    public int Quantity { get; set; }
}