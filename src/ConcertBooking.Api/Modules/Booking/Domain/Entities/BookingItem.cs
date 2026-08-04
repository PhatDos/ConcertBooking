using ConcertBooking.Api.Shared.Domain;

namespace ConcertBooking.Api.Modules.Booking.Domain.Entities;

public class BookingItem : BaseEntity
{
    private BookingItem()
    {
    }

    public BookingItem(
        Guid bookingId,
        Guid ticketCategoryId,
        int quantity,
        decimal unitPrice)
    {
        if (quantity <= 0)
            throw new ArgumentException(nameof(quantity));

        if (unitPrice <= 0)
            throw new ArgumentException(nameof(unitPrice));

        BookingId = bookingId;
        TicketCategoryId = ticketCategoryId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public Guid BookingId { get; private set; }

    public Guid TicketCategoryId { get; private set; }

    public int Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    public decimal TotalPrice => Quantity * UnitPrice;
}