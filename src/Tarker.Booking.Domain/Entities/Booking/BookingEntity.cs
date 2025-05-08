using System;
using Tarker.Booking.Domain.Entities.Customer;
using Tarker.Booking.Domain.Entities.User;

namespace Tarker.Booking.Domain.Entities.Booking;

/* The BookingEntity class represents a booking with properties such as BookingId, RegisterDate, Code,
Type, CustomerId, UserId, User, and Customer. */
public class BookingEntity
{
    public int BookingId { get; set; }
    public DateTime RegisterDate { get; set; }
    public string? Code { get; set; }
    public string? Type { get; set; }
    public int CustomerId { get; set; }
    public int UserId { get; set; }
    public UserEntity? User { get; set; }
    public CustomerEntity? Customer { get; set; }
}
