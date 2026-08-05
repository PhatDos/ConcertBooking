using System.ComponentModel.DataAnnotations;

namespace ConcertBooking.Api.Modules.Concert.Application.DTOs.Requests;

public class AddTicketCategoryRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = default!;

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(1, int.MaxValue)]
    public int TotalQuantity { get; set; }

    [Range(0, int.MaxValue)]
    public int DisplayOrder { get; set; }
}