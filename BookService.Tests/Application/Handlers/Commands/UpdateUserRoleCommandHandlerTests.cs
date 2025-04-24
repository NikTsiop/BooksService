using BooksService.Application.Commnands;
using BooksService.Application.Handlers.CommandsHandlers;
using BooksService.Application.Interfaces.DecorateInterfaces;
using BooksService.Application.Interfaces.Repositories;
using BooksService.Domain.Entities;
using Moq;
using static BooksService.Domain.Exceptions.UserExceptions;

namespace BooksService.Tests.Application.Handlers.Commands
{
    public class UpdateUserRoleCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock = new();
        private readonly Mock<IRoleRepository> _roleRepositoryMock = new();
        private readonly Mock<IUpdateRepository<User>> _updateRepositoryMock = new();
        private readonly UpdateUserRoleCommandHandler _handler;

        public UpdateUserRoleCommandHandlerTests()
        {
            _handler = new UpdateUserRoleCommandHandler(
                _userRepositoryMock.Object,
                _roleRepositoryMock.Object,
                _updateRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_UserNotFound_ThrowsUserNotFoundException()
        {
            // Arrange
            var command = new UpdateUserRoleCommand { UserId = 1, RoleIds = new List<long> { 1 } };
            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(command.UserId)).ReturnsAsync((User?)null);

            // Act & Assert
            await Assert.ThrowsAsync<UserNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_InvalidRoleIds_ThrowsArgumentException()
        {
            // Arrange
            var command = new UpdateUserRoleCommand { UserId = 1, RoleIds = new List<long> { 1, 2 } };
            var user = new User { Id = 1, FirstName = "Jane", Surname = "Doe", Role = new List<Role>() };
            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(command.UserId)).ReturnsAsync(user);
            _roleRepositoryMock.Setup(repo => repo.GetByIdsAsync(command.RoleIds)).ReturnsAsync(new List<Role> { new Role { Id = 1, RoleName = "Admin", Users = new List<User>() } });

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ValidRequest_UpdatesUserRoles()
        {
            // Arrange
            var command = new UpdateUserRoleCommand { UserId = 1, RoleIds = new List<long> { 1 } };
            var user = new User { Id = 1, FirstName = "John", Surname = "Smith", Role = new List<Role>() };
            var roles = new List<Role> { new Role { Id = 1, RoleName = "User", Users = new List<User>() } };

            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(command.UserId)).ReturnsAsync(user);
            _roleRepositoryMock.Setup(repo => repo.GetByIdsAsync(command.RoleIds)).ReturnsAsync(roles);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _updateRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<User>(u => u.Role.Count == 1 && u.Role.FirstOrDefault().Id == 1)), Times.Once);
        }
    }
}
