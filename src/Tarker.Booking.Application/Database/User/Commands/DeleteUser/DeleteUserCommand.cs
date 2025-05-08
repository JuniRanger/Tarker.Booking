namespace Tarker.Booking.Application.Database.User.Commands.DeleteUser;

public class DeleteUserCommand : IDeleteUserCommand
{
    private readonly IDatabaseService _databaseService;

    public DeleteUserCommand(IDatabaseService databaseService)
    {
        this._databaseService = databaseService;
    }

    public async Task<bool> Execute(int UserId) {
        var entity = await _databaseService.User.FindAsync(UserId) 
        ?? throw new KeyNotFoundException($"User with ID: {UserId} not found");

        _databaseService.User.Remove(entity);
        return await _databaseService.SaveAsync();
    }
}
