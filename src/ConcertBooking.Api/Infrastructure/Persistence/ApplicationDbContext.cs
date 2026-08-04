using ConcertBooking.Api.Modules.Booking.Domain.Entities;
using ConcertBooking.Api.Modules.Concert.Domain.Entities;
using ConcertBooking.Api.Modules.Payment.Domain.Entities;
using ConcertBooking.Api.Modules.User.Domain.Entities;
using ConcertBooking.Api.Modules.Voucher.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ConcertBooking.Api.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Concert> Concerts => Set<Concert>();

    public DbSet<TicketCategory> TicketCategories => Set<TicketCategory>();

    public DbSet<Booking> Bookings => Set<Booking>();

    public DbSet<BookingItem> BookingItems => Set<BookingItem>();

    public DbSet<Voucher> Vouchers => Set<Voucher>();

    public DbSet<VoucherRedemption> VoucherRedemptions => Set<VoucherRedemption>();

    public DbSet<Payment> Payments => Set<Payment>();

    public DbSet<BookingStatusHistory> BookingStatusHistories => Set<BookingStatusHistory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}