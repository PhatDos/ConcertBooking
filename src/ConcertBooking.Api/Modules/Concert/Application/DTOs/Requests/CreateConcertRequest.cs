using System.ComponentModel.DataAnnotations;

namespace ConcertBooking.Api.Modules.Concert.Application.DTOs.Requests;

public class CreateConcertRequest
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = default!;

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = default!;

    [Required]
    [MaxLength(200)]
    public string Venue { get; set; } = default!;

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }
}