namespace Tarker.Booking.Application.Database.User.Commands.CreateUser;

public class CreateUserModel
{
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
}

