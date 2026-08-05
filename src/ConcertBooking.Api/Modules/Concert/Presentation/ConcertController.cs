using ConcertBooking.Api.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConcertBooking.Api.Modules.Concert.Application.DTOs;
using ConcertEntity = ConcertBooking.Api.Modules.Concert.Domain.Entities.Concert;
using ConcertBooking.Api.Modules.Concert.Domain.Entities;

namespace ConcertBooking.Api.Modules.Concert.Presentation;

[ApiController]
[Route("api/concerts")]
public class ConcertController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ConcertController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var concerts = await _context.Concerts
            .Include(x => x.TicketCategories)
            .Select(c => new ConcertResponse(
                c.Id,
                c.Name,
                c.Description,
                c.Venue,
                c.StartTime,
                c.EndTime,
                c.Status,
                c.TicketCategories
                    .OrderBy(t => t.DisplayOrder)
                    .Select(t => new TicketCategoryResponse(
                        t.Id,
                        t.Name,
                        t.Price,
                        t.TotalQuantity,
                        t.ReservedQuantity,
                        t.SoldQuantity,
                        t.AvailableQuantity))
                    .ToList()
            ))
            .ToListAsync();

        return Ok(concerts);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateConcertRequest request)
    {
        try
        {
            var concert = new ConcertEntity(
                request.Name,
                request.Description,
                request.Venue,
                request.StartTime,
                request.EndTime);

            _context.Concerts.Add(concert);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetAll),
                null,
                new CreateConcertResponse(
                    concert.Id,
                    concert.Name,
                    concert.Status
                )
            );
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{concertId:guid}/ticket-categories")]
    public async Task<IActionResult> AddTicketCategory(
    Guid concertId,
    AddTicketCategoryRequest request)
    {
        var concertExists = await _context.Concerts
            .AnyAsync(x => x.Id == concertId);

        if (!concertExists)
            return NotFound("Concert not found.");

        var ticketCategory = new TicketCategory(
            concertId,
            request.Name,
            request.Price,
            request.TotalQuantity,
            request.DisplayOrder);

        _context.TicketCategories.Add(ticketCategory);

        await _context.SaveChangesAsync();

        return Ok(new AddTicketCategoryResponse(
            ticketCategory.Id,
            ticketCategory.Name,
            ticketCategory.Price,
            ticketCategory.TotalQuantity
        ));
    }
}
