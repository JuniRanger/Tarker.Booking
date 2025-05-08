using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Application.Database;
using Tarker.Booking.Domain.Entities.Booking;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;
using Tarker.Booking.Persistence.Configuration;

namespace Tarker.Booking.Persistence.Database;

public class DatabaseService : DbContext, IDatabaseService
{
    public DatabaseService(DbContextOptions options) : base(options) {}

/* The code snippet you provided in the `DatabaseService` class is defining properties for accessing
database tables/entities and a method for saving changes asynchronously in Entity Framework. */
    public DbSet<UserEntity> User { get; set; }
    public DbSet<CustomerEntity> Customer { get; set;}
    public DbSet<BookingEntity> Booking { get; set;}

/// <summary>
/// The SaveAsync method asynchronously saves changes and returns a boolean indicating if any changes
/// were saved.
/// </summary>
/// <returns>
/// The method `SaveAsync` is returning a `Task<bool>`. The `SaveAsync` method is an asynchronous method
/// that returns a task representing the completion of the operation, which will eventually produce a
/// boolean value.
/// </returns>
    public async Task<bool> SaveAsync() {
        return await SaveChangesAsync() > 0;
    }

/// <summary>
/// The OnModelCreating function in C# is used to configure entity models in Entity Framework.
/// </summary>
/// <param name="ModelBuilder">The `ModelBuilder` parameter in the `OnModelCreating` method is used to
/// configure the entity models for your database context. It allows you to define the shape of your
/// entities, their relationships, keys, indexes, and other database-specific configurations. By using
/// the `ModelBuilder`, you can customize how</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        EntityConfiguration(modelBuilder);
    }

/// <summary>
/// The function EntityConfiguration configures entity mappings for User, Customer, and Booking entities
/// using specific configuration classes.
/// </summary>
/// <param name="ModelBuilder">ModelBuilder is a class in Entity Framework that is used to configure the
/// model for a context. It is typically used to define the shape of the entities, their relationships,
/// and other configurations related to the database schema. In the provided code snippet, the
/// EntityConfiguration method is using the ModelBuilder instance to</param>
    private static void EntityConfiguration(ModelBuilder modelBuilder) {
        new UserConfiguration(modelBuilder.Entity<UserEntity>());
        new CustomerConfiguration(modelBuilder.Entity<CustomerEntity>());
        new BookingConfiguration(modelBuilder.Entity<BookingEntity>());
    }
}
