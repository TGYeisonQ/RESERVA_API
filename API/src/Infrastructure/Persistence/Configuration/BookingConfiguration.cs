

using Domain.Entities.Bookings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure (EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Booking");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title).IsRequired().HasMaxLength(30);

        builder.Property(b => b.Observations).IsRequired(false).HasMaxLength(100);

        builder.Property(b => b.DateBooking).IsRequired();
        
        builder.Property(b => b.UserId).IsRequired();

        builder.Property(b => b.ServiceId).IsRequired();

        builder.Property(b => b.Created).IsRequired();
        
        builder.HasOne(u => u.User).WithMany(b => b.Bookings).HasForeignKey(b => b.UserId);

        builder.HasOne(s => s.Service).WithMany(b => b.Bookings).HasForeignKey(b => b.ServiceId);

    }

}
