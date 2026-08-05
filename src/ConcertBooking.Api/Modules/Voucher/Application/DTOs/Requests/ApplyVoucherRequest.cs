using System.ComponentModel.DataAnnotations;

namespace ConcertBooking.Api.Modules.Voucher.Application.DTOs.Requests;

public class ApplyVoucherRequest
{
    [Required]
    public Guid VoucherId { get; set; }
}