using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarker.Booking.Domain.Entities.Customer;

namespace Tarker.Booking.Persistence.Configuration;

public class CustomerConfiguration
{
    /// <summary>
    /// Initializes a new instance of the CustomerConfiguration class and configures the Customer entity.
    /// </summary>
    /// <param name="entityBuilder">The EntityTypeBuilder instance used to configure the Customer entity.</param>
    public CustomerConfiguration(EntityTypeBuilder<CustomerEntity> entityBuilder)
    {
        /* This code snippet is configuring the primary key and required properties for the `CustomerEntity`
        entity in Entity Framework Core. */
        entityBuilder.HasKey(c => c.CustomerId);
        entityBuilder.Property(c => c.FullName).IsRequired();
        entityBuilder.Property(c => c.DocumentNumber).IsRequired();

        /* This code snippet is configuring a one-to-many relationship between the `CustomerEntity` and
        `BookingEntity` entities in an Entity Framework Core context. */
        entityBuilder.HasMany(c => c.Bookings)
            .WithOne(c => c.Customer)
            .HasForeignKey(c => c.CustomerId);
    }
}
