using System.ComponentModel.DataAnnotations;

namespace ConcertBooking.Api.Modules.Payment.Application.DTOs.Requests;

public class ProcessPaymentRequest
{
    [Required]
    [MaxLength(50)]
    public string PaymentMethod { get; set; } = "Mock";
}