using BookTracker.BusinessLogic.Enums;
using BookTracker.Persistence;
using BookTracker.Persistence.Entities;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.BusinessLogic.Features.Commands.AddUser;

public class AddUserCommandHandler : ICommandHandler<AddUserCommand> 
{
    private readonly IBookTrackerDbContext _context;

    public AddUserCommandHandler (IBookTrackerDbContext context) 
    {
        _context = context;
    }
    public async ValueTask<Unit> Handle(AddUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _context.User.FirstOrDefaultAsync(
            x => x.Login == command.Login || x.Email == command.Email, 
            cancellationToken);
        
        if (user is not null)
        {
            throw new Exception("User not found"); //создать свои ошибки 
        }

        var newUser = new User
        {
            Login = command.Login,
            Email = command.Email,
            PasswordHash = command.Password,
            FirstName = command.FirstName,
            LastName = command.LastName,
            RoleId = (int)RoleType.User
        };

        await _context.User.AddAsync(newUser, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
