using ConcertBooking.Api.Modules.Booking.Domain.Enums;

namespace ConcertBooking.Api.Modules.Booking.Application.DTOs;

public class UpdateBookingStatusRequest
{
    public BookingStatus Status { get; set; }
}