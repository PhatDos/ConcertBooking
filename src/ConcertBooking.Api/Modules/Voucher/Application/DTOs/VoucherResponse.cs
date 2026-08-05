using ConcertBooking.Api.Modules.Voucher.Domain.Enums;

namespace ConcertBooking.Api.Modules.Voucher.Application.DTOs;

public sealed record VoucherResponse(
    Guid Id,
    string Code,
    DiscountType DiscountType,
    decimal DiscountValue,
    int TotalQuantity,
    DateTime StartDate,
    DateTime EndDate
);