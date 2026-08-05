using System.ComponentModel.DataAnnotations;
using ConcertBooking.Api.Modules.Booking.Domain.Enums;

namespace ConcertBooking.Api.Modules.Booking.Application.DTOs.Requests;

public class UpdateBookingStatusRequest
{
    [Required]
    public BookingStatus Status { get; set; }
}