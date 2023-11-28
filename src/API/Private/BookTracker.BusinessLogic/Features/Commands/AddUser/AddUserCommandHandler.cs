﻿using BookTracker.BusinessLogic.Exceptions.User;
using BookTracker.BusinessLogic.Services.Password;
using BookTracker.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.BusinessLogic.Features.Commands.AddUser;

public class AddUserCommandHandler : ICommandHandler<AddUserCommand> 
{
    private readonly IBookTrackerDbContext _context;
    private readonly IPasswordService _passwordSevice;

    public AddUserCommandHandler (IBookTrackerDbContext context, IPasswordService passwordService) 
    {
        _context = context;
        _passwordSevice = passwordService;
    }
    public async ValueTask<Unit> Handle(AddUserCommand command, CancellationToken cancellationToken)
    {
        await ValidateIfUserExistsAsync(command, cancellationToken);

        var passwordHash = _passwordSevice.HashPassword(command.Password);
        var newUser = command.ToUser(passwordHash);

        await _context.User.AddAsync(newUser, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

    private async Task ValidateIfUserExistsAsync(AddUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _context.User.FirstOrDefaultAsync(
            x => x.Login == command.Login || x.Email == command.Email,
            cancellationToken);

        if (user is not null)
        {
            throw new UserAlreadyExistsException();
        }
    }
}

