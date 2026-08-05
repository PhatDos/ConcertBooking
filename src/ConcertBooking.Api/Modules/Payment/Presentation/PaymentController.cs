using ConcertBooking.Api.Infrastructure.Persistence;
using ConcertBooking.Api.Modules.Booking.Domain.Enums;
using ConcertBooking.Api.Modules.Payment.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcertBooking.Api.Modules.Payment.Presentation;

[ApiController]
[Route("api/payments")]
public class PaymentController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PaymentController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("{bookingId:guid}")]
    public async Task<IActionResult> Process(
        Guid bookingId,
        ProcessPaymentRequest request)
    {
        var booking = await _context.Bookings
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == bookingId);

        if (booking == null)
            return NotFound("Booking not found.");

        if (booking.Status != BookingStatus.PendingPayment)
            return BadRequest("Booking is not pending payment.");

        await using var transaction =
            await _context.Database.BeginTransactionAsync();

        try
        {
            foreach (var item in booking.Items)
            {
                var ticket = await _context.TicketCategories
                    .FirstOrDefaultAsync(x => x.Id == item.TicketCategoryId);

                if (ticket == null)
                    return BadRequest(
                        $"Ticket category '{item.TicketCategoryId}' not found.");

                // Convert reserved tickets into sold tickets
                ticket.ConfirmReservation(item.Quantity);
            }

            booking.Confirm();

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return Ok(new PaymentResponse(
                booking.Id,
                booking.Status,
                request.PaymentMethod,
                "Payment completed successfully."
            ));
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();

            return StatusCode(500, new
            {
                Message = "Payment failed."
            });
        }
    }
}