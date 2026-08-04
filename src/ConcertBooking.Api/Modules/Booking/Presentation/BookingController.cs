using ConcertBooking.Api.Infrastructure.Persistence;
using ConcertBooking.Api.Modules.Booking.Application.DTOs;
using ConcertBooking.Api.Modules.Booking.Domain.Enums;
using ConcertBooking.Api.Modules.Voucher.Application.DTOs;
using ConcertBooking.Api.Modules.Voucher.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingEntity = ConcertBooking.Api.Modules.Booking.Domain.Entities.Booking;
using BookingItemEntity = ConcertBooking.Api.Modules.Booking.Domain.Entities.BookingItem;

namespace ConcertBooking.Api.Modules.Booking.Presentation;

[ApiController]
[Route("api/bookings")]
public class BookingController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BookingController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var booking = await _context.Bookings
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (booking == null)
            return NotFound();

        return Ok(new
        {
            booking.Id,
            booking.Status,
            booking.SubTotal,
            booking.DiscountAmount,
            booking.FinalAmount,
            booking.ExpiresAt,

            Items = booking.Items.Select(x => new
            {
                x.TicketCategoryId,
                x.Quantity,
                x.UnitPrice,
                x.TotalPrice
            })
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var bookings = await _context.Bookings
            .Select(x => new
            {
                x.Id,
                x.UserId,
                x.ConcertId,
                x.Status,

                x.SubTotal,
                x.DiscountAmount,
                x.FinalAmount,

                x.ExpiresAt
            })
            .ToListAsync();

        return Ok(bookings);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookingRequest request)
    {
        try
        {
            // Prevent duplicate booking caused by client retries
            var existingBooking = await _context.Bookings
                .FirstOrDefaultAsync(x => x.IdempotencyKey == request.IdempotencyKey);

            if (existingBooking != null)
            {
                return Ok(new
                {
                    existingBooking.Id,
                    existingBooking.Status,
                    existingBooking.FinalAmount
                });
            }

            // Validate concert
            var concert = await _context.Concerts
                .FirstOrDefaultAsync(x => x.Id == request.ConcertId);

            if (concert == null)
            {
                return BadRequest(
                    $"Concert '{request.ConcertId}' not found.");
            }

            var booking = new BookingEntity(
                request.UserId,
                request.ConcertId,
                request.IdempotencyKey,
                DateTime.UtcNow.AddMinutes(10));

            _context.Bookings.Add(booking);

            foreach (var item in request.Items)
            {
                // Validate ticket belongs to this concert
                var ticket = await _context.TicketCategories
                    .FirstOrDefaultAsync(x =>
                        x.Id == item.TicketCategoryId &&
                        x.ConcertId == request.ConcertId);

                if (ticket == null)
                {
                    return BadRequest(
                        $"Ticket category '{item.TicketCategoryId}' not found for concert '{request.ConcertId}'.");
                }

                // Reserve tickets
                ticket.Reserve(item.Quantity);

                var bookingItem = new BookingItemEntity(
                    booking.Id,
                    item.TicketCategoryId,
                    item.Quantity,
                    ticket.Price);

                booking.AddItem(bookingItem);

                _context.BookingItems.Add(bookingItem);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Get),
                new { id = booking.Id },
                new
                {
                    booking.Id,
                    booking.Status,
                    booking.SubTotal,
                    booking.DiscountAmount,
                    booking.FinalAmount,
                    booking.ExpiresAt
                });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPatch("{id:guid}/status")]
    public async Task<IActionResult> UpdateStatus(
    Guid id,
    UpdateBookingStatusRequest request)
    {
        var booking = await _context.Bookings
            .FirstOrDefaultAsync(x => x.Id == id);

        if (booking == null)
            return NotFound("Booking not found.");

        switch (request.Status)
        {
            case BookingStatus.Confirmed:
                booking.Confirm();
                break;

            case BookingStatus.Cancelled:
                booking.Cancel();
                break;

            case BookingStatus.Expired:
                booking.Expire();
                break;

            default:
                return BadRequest("Invalid booking status.");
        }

        await _context.SaveChangesAsync();

        return Ok(new
        {
            booking.Id,
            booking.Status
        });
    }

    [HttpPost("{id:guid}/apply-voucher")]
    public async Task<IActionResult> ApplyVoucher(
    Guid id,
    ApplyVoucherRequest request)
    {
        var booking = await _context.Bookings
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (booking == null)
            return NotFound("Booking not found.");

        var voucher = await _context.Vouchers
            .FirstOrDefaultAsync(x => x.Id == request.VoucherId);

        if (voucher == null)
            return BadRequest("Voucher not found.");

        try
        {
            voucher.Redeem();

            decimal discount = voucher.DiscountType switch
            {
                DiscountType.FixedAmount => voucher.DiscountValue,

                DiscountType.Percentage =>
                    booking.SubTotal * voucher.DiscountValue / 100,

                _ => 0
            };

            booking.ApplyVoucher(voucher.Id, discount);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                booking.Id,
                booking.DiscountAmount,
                booking.FinalAmount
            });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
