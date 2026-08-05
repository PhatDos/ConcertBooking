using System.ComponentModel.DataAnnotations;
using ConcertBooking.Api.Modules.Voucher.Domain.Enums;

namespace ConcertBooking.Api.Modules.Voucher.Application.DTOs.Requests;

public class CreateVoucherRequest
{
    [Required]
    [MaxLength(50)]
    public string Code { get; set; } = default!;

    [Required]
    public DiscountType DiscountType { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal DiscountValue { get; set; }

    [Range(1, int.MaxValue)]
    public int TotalQuantity { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }
}