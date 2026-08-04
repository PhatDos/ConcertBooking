using ConcertBooking.Api.Modules.Voucher.Domain.Enums;
using ConcertBooking.Api.Shared.Domain;

namespace ConcertBooking.Api.Modules.Voucher.Domain.Entities;

public class Voucher : BaseEntity
{
    private Voucher()
    {
    }

    public Voucher(
        string code,
        DiscountType discountType,
        decimal discountValue,
        int totalQuantity,
        DateTime startDate,
        DateTime endDate)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException(nameof(code));

        if (discountValue <= 0)
            throw new ArgumentException(nameof(discountValue));

        if (totalQuantity <= 0)
            throw new ArgumentException(nameof(totalQuantity));

        if (endDate <= startDate)
            throw new ArgumentException(nameof(endDate));

        Code = code.Trim();
        DiscountType = discountType;
        DiscountValue = discountValue;
        TotalQuantity = totalQuantity;
        StartDate = startDate;
        EndDate = endDate;
    }

    public Guid? ConcertId { get; private set; }

    public string Code { get; private set; } = default!;

    public DiscountType DiscountType { get; private set; }

    public decimal DiscountValue { get; private set; }

    public int TotalQuantity { get; private set; }

    public int UsedQuantity { get; private set; }

    public DateTime StartDate { get; private set; }

    public DateTime EndDate { get; private set; }

    public bool IsActive =>
        DateTime.UtcNow >= StartDate &&
        DateTime.UtcNow <= EndDate;

    public void Redeem()
    {
        if (!IsActive)
            throw new InvalidOperationException("Voucher is inactive.");

        if (UsedQuantity >= TotalQuantity)
            throw new InvalidOperationException("Voucher has run out.");

        UsedQuantity++;
    }
}