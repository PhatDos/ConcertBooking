namespace ConcertBooking.Api.Modules.Concert.Application.DTOs;

public class AddTicketCategoryRequest
{
    public string Name { get; set; } = default!;

    public decimal Price { get; set; }

    public int TotalQuantity { get; set; }

    public int DisplayOrder { get; set; }
}