using BooksService.Application.Commnands;
using BooksService.Application.Interfaces.DecorateInterfaces;
using BooksService.Application.Interfaces.Repositories;
using BooksService.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using static BooksService.Domain.Exceptions.CategoryExceptions;

namespace BooksService.Application.Handlers.CommandsHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IBooksRepository _booksRepository;
        private readonly IDeleteRepository<Category> _deleteRepository;
        private readonly ILogger<DeleteCategoryCommandHandler> _logger;

        public DeleteCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IBooksRepository booksRepository,
            IDeleteRepository<Category> deleteRepository,
            ILogger<DeleteCategoryCommandHandler> logger
        )
        {
            _categoryRepository = categoryRepository;
            _booksRepository = booksRepository;
            _deleteRepository = deleteRepository;
            _logger = logger;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // Design decision:
            // Prevent deletion if any books exist for this category.
            // This protects data integrity and invites explicit user action if cleanup is needed.

            _logger.LogInformation("Handling DeleteCategoryCommand for CategoryId: {CategoryId}", request.CategoryId);

            var category = await _categoryRepository.GetByIdAsync(request.CategoryId) ??
                throw new CategoryNotFoundException();

            var books = await _booksRepository.GetByCategoryIdAsync(request.CategoryId);

            // Ensure no books are associated before deleting category
            category.EnsureDeletable(books);

            await _deleteRepository.DeleteAsync(category);
        }
    }
}
