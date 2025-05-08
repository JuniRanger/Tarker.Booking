using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Persistence.Configuration;

public class BookingConfiguration
{
    public BookingConfiguration(EntityTypeBuilder<BookingEntity> entityBuilder) 
    {    
        entityBuilder.HasKey(b => b.BookingId);
        entityBuilder.Property(b => b.RegisterDate).IsRequired();
        entityBuilder.Property(b => b.Code).IsRequired();
        entityBuilder.Property(b => b.Type).IsRequired();
        entityBuilder.Property(b => b.UserId).IsRequired();
        entityBuilder.Property(b => b.CustomerId).IsRequired();

    /* This code snippet is configuring a relationship between the `BookingEntity` entity and the `User`
    entity in Entity Framework Core. */
        entityBuilder.HasOne(b => b.User)
            .WithMany(b => b.Bookings)
            .HasForeignKey(b => b.UserId);

    /* This code snippet is configuring a relationship between the `BookingEntity` entity and the
    `Customer` entity in Entity Framework Core. */
        entityBuilder.HasOne(b => b.Customer)
            .WithMany(b => b.Bookings)
            .HasForeignKey(b => b.CustomerId);
    }
}
