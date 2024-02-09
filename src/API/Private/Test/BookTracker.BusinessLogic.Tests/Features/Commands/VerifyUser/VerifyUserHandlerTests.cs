﻿using AutoFixture;
using BookTracker.BusinessLogic.Exceptions.User;
using BookTracker.BusinessLogic.Features.Commands.VerifyUser;
using BookTracker.BusinessLogic.Services.Password;
using BookTracker.Persistence.Entities;
using FluentAssertions;
using NSubstitute;

namespace BookTracker.BusinessLogic.Tests.Features.Commands.VerifyUser; 
public class VerifyUserHandlerTests : TestBase
{
    private IPasswordService _passwordService = null!;
    private VerifyUserHandler _handler = null!;

    public override void SetUp() 
    {
        base.SetUp();

        _passwordService = Substitute.For<IPasswordService>(); //в IPasswordService захэшируй и проверь. А здесь мы мокаем 
        _handler = new VerifyUserHandler(DbContextFactory, _passwordService);
    }

    [OneTimeSetUp]
    public void OneTimeSetUp() {
        Fixture.Behaviors
            .OfType<ThrowingRecursionBehavior>()
            .ToList()
            .ForEach(b => Fixture.Behaviors.Remove(b));

        Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Test]
    public async Task Handle_WhenUserExistsAndValid_ShouldNotThrowException() 
    {
        // Arrange
        var command = Fixture.Create<VerifyUserCommand>();

        var user = Fixture
            .Build<User>()
            .Without(x => x.Role)
            .Without(x => x.UserBooks)
            .With(x => x.RoleId, 3)
            .With(x => x.Login, command.EmailOrLogin)
            .Create();

        await DbContext.User.AddAsync(user);
        await DbContext.SaveChangesAsync();

        _passwordService.VerifyPassword(command.Password, user.PasswordHash).Returns(true);

        // Act & Assert
        await _handler
            .Invoking(async handler => await handler.Handle(command, CancellationToken.None))
            .Should()
            .NotThrowAsync();

        _passwordService.Received().VerifyPassword(command.Password, user.PasswordHash);
    }

    [Test]
    public async Task Handle_WhenUserDoesNotExist_ShouldThrowException() 
    {
        // Arrange       
        var command = Fixture.Create<VerifyUserCommand>();

        // Act & Assert
        await _handler
            .Invoking(async handler => await handler.Handle(command, CancellationToken.None))
            .Should()            
            .ThrowExactlyAsync<InvalidCredentials>();
    }

    [Test]
    public async Task Handle_WhenUserExistsButInvalid_ShouldThrowException() 
    {
        // Arrange 
        var command = Fixture.Create<VerifyUserCommand>();

        var user = Fixture
            .Build<User>()
            .Without(x => x.Role)
            .Without(x => x.UserBooks)
            .With(x => x.RoleId, 3)
            .With(x => x.Login, command.EmailOrLogin)
            .Create();

        await DbContext.User.AddAsync(user);
        await DbContext.SaveChangesAsync();

        _passwordService.VerifyPassword(command.Password, user.PasswordHash).Returns(false);

        // Act & Assert 
        await _handler
            .Invoking(async handler => await handler.Handle(command, CancellationToken.None))
            .Should()
            .ThrowExactlyAsync<InvalidCredentials>();
    }
}
