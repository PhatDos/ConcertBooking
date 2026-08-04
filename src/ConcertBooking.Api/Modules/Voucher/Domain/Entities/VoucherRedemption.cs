using ConcertBooking.Api.Shared.Domain;

namespace ConcertBooking.Api.Modules.Voucher.Domain.Entities;

public class VoucherRedemption : BaseEntity
{
    private VoucherRedemption()
    {
    }

    public VoucherRedemption(
        Guid voucherId,
        Guid userId,
        Guid bookingId)
    {
        VoucherId = voucherId;
        UserId = userId;
        BookingId = bookingId;
        RedeemedAt = DateTime.UtcNow;
    }

    public Guid VoucherId { get; private set; }

    public Guid UserId { get; private set; }

    public Guid BookingId { get; private set; }

    public DateTime RedeemedAt { get; private set; }
}