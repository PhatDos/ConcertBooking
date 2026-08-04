using ConcertBooking.Api.Modules.Concert.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConcertBooking.Api.Infrastructure.Persistence.Configurations;

public class ConcertConfiguration : IEntityTypeConfiguration<Concert>
{
    public void Configure(EntityTypeBuilder<Concert> builder)
    {
        builder.ToTable("Concerts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(1000);

        builder.Property(x => x.Venue)
            .HasMaxLength(200);

        builder.Property(x => x.Status)
            .HasConversion<int>();

        builder.HasMany(x => x.TicketCategories)
            .WithOne(x => x.Concert)
            .HasForeignKey(x => x.ConcertId);
    }
}