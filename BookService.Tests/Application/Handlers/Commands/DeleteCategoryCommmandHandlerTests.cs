using BooksService.Application.Commnands;
using BooksService.Application.Handlers.CommandsHandlers;
using BooksService.Application.Interfaces.DecorateInterfaces;
using BooksService.Application.Interfaces.Repositories;
using BooksService.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using static BooksService.Domain.Exceptions.CategoryExceptions;

namespace BooksService.Tests.Application.Handlers.Commands
{
    public class DeleteCategoryCommandHandlerTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock = new();
        private readonly Mock<IBooksRepository> _booksRepositoryMock = new();
        private readonly Mock<IDeleteRepository<Category>> _deleteRepositoryMock = new();
        private readonly Mock<ILogger<DeleteCategoryCommandHandler>> _loggerMock = new();
        private readonly DeleteCategoryCommandHandler _handler;

        public DeleteCategoryCommandHandlerTests()
        {
            _handler = new DeleteCategoryCommandHandler(
                _categoryRepositoryMock.Object,
                _booksRepositoryMock.Object,
                _deleteRepositoryMock.Object,
                _loggerMock.Object
            );
        }

        [Fact]
        public async Task Handle_CategoryNotFound_ThrowsCategoryNotFoundException()
        {
            // Arrange
            var command = new DeleteCategoryCommand { CategoryId = 1 };
            _categoryRepositoryMock.Setup(repo => repo.GetByIdAsync(command.CategoryId))
                .ReturnsAsync((Category?)null);

            // Act & Assert
            await Assert.ThrowsAsync<CategoryNotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_CategoryHasBooks_ThrowsCategoryInUseException()
        {
            // Arrange
            var command = new DeleteCategoryCommand { CategoryId = 1 };
            var category = new Category { Id = 1, Name = "Fantasy" };
            var books = new List<Book> { new Book { Id = 1, Title = "Book 1", CategoryId = 1 } };

            _categoryRepositoryMock.Setup(repo => repo.GetByIdAsync(command.CategoryId))
                .ReturnsAsync(category);
            _booksRepositoryMock.Setup(repo => repo.GetByCategoryIdAsync(command.CategoryId))
                .ReturnsAsync(books);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ValidCategory_DeletesCategory()
        {
            // Arrange
            var command = new DeleteCategoryCommand { CategoryId = 1 };
            var category = new Category { Id = 1, Name = "History" };
            var books = new List<Book>(); // No books

            _categoryRepositoryMock.Setup(repo => repo.GetByIdAsync(command.CategoryId))
                .ReturnsAsync(category);
            _booksRepositoryMock.Setup(repo => repo.GetByCategoryIdAsync(command.CategoryId))
                .ReturnsAsync(books);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _deleteRepositoryMock.Verify(r => r.DeleteAsync(category), Times.Once);
        }
    }
}
