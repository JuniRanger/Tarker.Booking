using System;
using Microsoft.EntityFrameworkCore;
using Tarker.Booking.Domain.Entities.User;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.Booking;

namespace Tarker.Booking.Application.Database;

public interface IDatabaseService
{
    public DbSet<UserEntity> User  { get; set; }
    public DbSet<CustomerEntity> Customer  { get; set; }
    public DbSet<BookingEntity> Booking  { get; set; }
    public Task<bool> SaveAsync();
}
