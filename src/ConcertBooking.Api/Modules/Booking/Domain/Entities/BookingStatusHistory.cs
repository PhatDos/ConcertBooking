using ConcertBooking.Api.Modules.Booking.Domain.Enums;
using ConcertBooking.Api.Shared.Domain;

namespace ConcertBooking.Api.Modules.Booking.Domain.Entities;

public class BookingStatusHistory : BaseEntity
{
    private BookingStatusHistory()
    {
    }

    public BookingStatusHistory(
        Guid bookingId,
        BookingStatus fromStatus,
        BookingStatus toStatus,
        Guid? changedBy,
        string? reason)
    {
        BookingId = bookingId;
        FromStatus = fromStatus;
        ToStatus = toStatus;
        ChangedBy = changedBy;
        Reason = reason;
        ChangedAt = DateTime.UtcNow;
    }

    public Guid BookingId { get; private set; }

    public BookingStatus FromStatus { get; private set; }

    public BookingStatus ToStatus { get; private set; }

    public Guid? ChangedBy { get; private set; }

    public string? Reason { get; private set; }

    public DateTime ChangedAt { get; private set; }
}