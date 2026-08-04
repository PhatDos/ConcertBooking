namespace ConcertBooking.Api.Modules.Booking.Domain.Enums;

public enum BookingStatus
{
    PendingPayment = 0,
    Confirmed = 1,
    Failed = 2,
    Cancelled = 3,
    Expired = 4
}