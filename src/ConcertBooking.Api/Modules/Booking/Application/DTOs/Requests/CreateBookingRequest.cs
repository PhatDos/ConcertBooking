using System.ComponentModel.DataAnnotations;

namespace ConcertBooking.Api.Modules.Booking.Application.DTOs.Requests;

public class CreateBookingRequest
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public Guid ConcertId { get; set; }

    [Required]
    [MaxLength(100)]
    public string IdempotencyKey { get; set; } = default!;

    public Guid? VoucherId { get; set; }

    [Required]
    [MinLength(1)]
    public List<CreateBookingItemRequest> Items { get; set; } = [];
}