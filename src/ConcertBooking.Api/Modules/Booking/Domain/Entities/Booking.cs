using ConcertBooking.Api.Modules.Booking.Domain.Enums;
using ConcertBooking.Api.Shared.Domain;

namespace ConcertBooking.Api.Modules.Booking.Domain.Entities;

public class Booking : BaseEntity
{
    private readonly List<BookingItem> _items = [];

    private Booking()
    {
    }

    public Booking(
        Guid userId,
        Guid concertId,
        string idempotencyKey,
        DateTime expiresAt)
    {
        if (string.IsNullOrWhiteSpace(idempotencyKey))
            throw new ArgumentException(nameof(idempotencyKey));

        UserId = userId;
        ConcertId = concertId;
        IdempotencyKey = idempotencyKey;
        ExpiresAt = expiresAt;

        Status = BookingStatus.PendingPayment;
    }

    public Guid UserId { get; private set; }

    public Guid ConcertId { get; private set; }

    public Guid? VoucherId { get; private set; }

    public string IdempotencyKey { get; private set; } = default!;

    public BookingStatus Status { get; private set; }

    public decimal SubTotal { get; private set; }

    public decimal DiscountAmount { get; private set; }

    public decimal FinalAmount { get; private set; }

    public DateTime ExpiresAt { get; private set; }

    public IReadOnlyCollection<BookingItem> Items
        => _items.AsReadOnly();

    public void AddItem(BookingItem item)
    {
        _items.Add(item);

        RecalculateAmount();
    }

    public void ApplyVoucher(Guid voucherId, decimal discount)
    {
        VoucherId = voucherId;
        DiscountAmount = discount;

        RecalculateAmount();
    }

    public void Confirm()
    {
        Status = BookingStatus.Confirmed;
    }

    public void Cancel()
    {
        Status = BookingStatus.Cancelled;
    }

    public void Expire()
    {
        Status = BookingStatus.Expired;
    }

    private void RecalculateAmount()
    {
        SubTotal = _items.Sum(x => x.TotalPrice);

        FinalAmount = SubTotal - DiscountAmount;

        if (FinalAmount < 0)
            FinalAmount = 0;
    }
}