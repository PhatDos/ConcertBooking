using ConcertBooking.Api.Infrastructure.Persistence;
using ConcertBooking.Api.Modules.Voucher.Application.DTOs.Requests;
using ConcertBooking.Api.Modules.Voucher.Application.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using VoucherEntity = ConcertBooking.Api.Modules.Voucher.Domain.Entities.Voucher;

namespace ConcertBooking.Api.Modules.Voucher.Presentation;

[ApiController]
[Route("api/vouchers")]
public class VoucherController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VoucherController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateVoucherRequest request)
    {
        try
        {
            var voucher = new VoucherEntity(
                request.Code,
                request.DiscountType,
                request.DiscountValue,
                request.TotalQuantity,
                request.StartDate,
                request.EndDate);

            _context.Vouchers.Add(voucher);

            await _context.SaveChangesAsync();

            return Created(
                $"/api/vouchers/{voucher.Id}",
                new VoucherResponse(
                    voucher.Id,
                    voucher.Code,
                    voucher.DiscountType,
                    voucher.DiscountValue,
                    voucher.TotalQuantity,
                    voucher.StartDate,
                    voucher.EndDate));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}