using ConcertBooking.Api.Modules.Voucher.Domain.Enums;

namespace ConcertBooking.Api.Modules.Voucher.Application.DTOs;

public class CreateVoucherRequest
{
    public string Code { get; set; } = default!;

    public DiscountType DiscountType { get; set; }

    public decimal DiscountValue { get; set; }

    public int TotalQuantity { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}