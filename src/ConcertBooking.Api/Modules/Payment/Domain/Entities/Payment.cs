using ConcertBooking.Api.Modules.Payment.Domain.Enums;
using ConcertBooking.Api.Shared.Domain;

namespace ConcertBooking.Api.Modules.Payment.Domain.Entities;

public class Payment : BaseEntity
{
    private Payment()
    {
    }

    public Payment(Guid bookingId, decimal amount)
    {
        BookingId = bookingId;
        Amount = amount;
        Status = PaymentStatus.Pending;
    }

    public Guid BookingId { get; private set; }

    public decimal Amount { get; private set; }

    public PaymentStatus Status { get; private set; }

    public string? TransactionCode { get; private set; }

    public DateTime? PaidAt { get; private set; }

    public void Complete(string transactionCode)
    {
        Status = PaymentStatus.Paid;
        TransactionCode = transactionCode;
        PaidAt = DateTime.UtcNow;
    }

    public void Fail()
    {
        Status = PaymentStatus.Failed;
    }
}