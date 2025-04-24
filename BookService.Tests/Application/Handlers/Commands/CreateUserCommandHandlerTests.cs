using BooksService.Application.Commnands;
using BooksService.Application.Handlers.CommandsHandlers;
using BooksService.Application.Interfaces.DecorateInterfaces;
using BooksService.Application.Interfaces.Repositories;
using BooksService.Domain.Entities;
using Moq;
using static BooksService.Domain.Exceptions.UserExceptions;

namespace BooksService.Tests.Application.Handlers.Commands;

public class CreateUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock = new();
    private readonly Mock<IAddRepository<User>> _addRepositoryMock = new();
    private readonly CreateUserCommandHandler _handler;

    public CreateUserCommandHandlerTests()
    {
        _handler = new CreateUserCommandHandler(_userRepositoryMock.Object, _addRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnTrue_WhenUserIsCreatedSuccessfully()
    {
        // Arrange
        var command = new CreateUserCommand { FirstName = "John", Surname = "Doe" };
        _userRepositoryMock.Setup(r => r.GetByUserInfo(It.IsAny<User>())).ReturnsAsync((User)null);
        _addRepositoryMock.Setup(r => r.AddAsync(It.IsAny<User>())).ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
        _addRepositoryMock.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowDuplicateUserException_WhenUserAlreadyExists()
    {
        // Arrange
        var command = new CreateUserCommand { FirstName = "John", Surname = "Doe" };
        _userRepositoryMock.Setup(r => r.GetByUserInfo(It.IsAny<User>()))
            .ReturnsAsync(new User { Role = new List<Role>() }); 

        // Act & Assert
        await Assert.ThrowsAsync<DuplicateUserException>(() => _handler.Handle(command, CancellationToken.None));
        _addRepositoryMock.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Never);
    }
}
