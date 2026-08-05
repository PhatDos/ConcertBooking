using ConcertBooking.Api.Shared.Domain;
using System.Text.Json.Serialization;

namespace ConcertBooking.Api.Modules.Concert.Domain.Entities;

public class TicketCategory : BaseEntity
{
    private TicketCategory()
    {
    }

    public TicketCategory(
    Guid concertId,
    string name,
    decimal price,
    int totalQuantity,
    int displayOrder)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Ticket category name is required.");

        if (price <= 0)
            throw new ArgumentException("Ticket price must be greater than zero.");

        if (totalQuantity <= 0)
            throw new ArgumentException("Total quantity must be greater than zero.");

        ConcertId = concertId;
        Name = name.Trim();
        Price = price;
        TotalQuantity = totalQuantity;
        DisplayOrder = displayOrder;
    }

    public Guid ConcertId { get; private set; }

    public Concert Concert { get; private set; } = default!;

    public string Name { get; private set; } = default!;

    public decimal Price { get; private set; }

    public int TotalQuantity { get; private set; }

    public int ReservedQuantity { get; private set; }

    public int SoldQuantity { get; private set; }

    public int DisplayOrder { get; private set; }

    // Optimistic Concurrency
    public byte[] RowVersion { get; private set; } = default!;

    // Computed property - không lưu DB
    public int AvailableQuantity
        => TotalQuantity - ReservedQuantity - SoldQuantity;

    // Chỉ BookingService nên gọi
    public void Reserve(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        if (AvailableQuantity < quantity)
            throw new InvalidOperationException("Not enough available tickets.");

        ReservedQuantity += quantity;
    }

    // Sau khi thanh toán thành công
    public void ConfirmReservation(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        if (ReservedQuantity < quantity)
            throw new InvalidOperationException("Reserved quantity is insufficient.");

        ReservedQuantity -= quantity;
        SoldQuantity += quantity;
    }

    // Hết thời gian giữ vé hoặc hủy
    public void ReleaseReservation(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        if (ReservedQuantity < quantity)
            throw new InvalidOperationException("Reserved quantity is insufficient.");

        ReservedQuantity -= quantity;
    }

    // Chỉ dùng cho Admin
    public void UpdatePrice(decimal price)
    {
        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero.");

        if (ReservedQuantity > 0 || SoldQuantity > 0)
            throw new InvalidOperationException(
                "Cannot change price while tickets are reserved or sold.");

        Price = price;
    }

    // Chỉ dùng cho Admin
    public void UpdateTotalQuantity(int totalQuantity)
    {
        if (totalQuantity < ReservedQuantity + SoldQuantity)
            throw new InvalidOperationException(
                "Total quantity cannot be less than reserved and sold tickets.");

        TotalQuantity = totalQuantity;
    }
}