using System.ComponentModel.DataAnnotations;

namespace ConcertBooking.Api.Modules.Booking.Application.DTOs.Requests;

public class CreateBookingItemRequest
{
    [Required]
    public Guid TicketCategoryId { get; set; }

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}