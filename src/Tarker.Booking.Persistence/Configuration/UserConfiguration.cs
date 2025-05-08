using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Persistence.Configuration;

/* The UserConfiguration class defines configuration settings for the UserEntity entity in C#. */
public class UserConfiguration
{
    public UserConfiguration(EntityTypeBuilder<UserEntity> entityBuilder)
    {
        /* The code snippet you provided is configuring the properties of the `UserEntity` entity in C# using
        Entity Framework Core's Fluent API. Here's a breakdown of what each line is doing: */
        entityBuilder.HasKey(u => u.UserId);
        entityBuilder.Property(u => u.FirstName).IsRequired();
        entityBuilder.Property(u => u.LastName).IsRequired();
        entityBuilder.Property(u => u.UserName).IsRequired();
        entityBuilder.Property(u => u.Password).IsRequired();

        /* This code snippet is configuring a one-to-many relationship between the `UserEntity` entity
        and the `Bookings` entity in Entity Framework Core using the Fluent API. */
        entityBuilder.HasMany(u => u.Bookings)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId);
    }
}
