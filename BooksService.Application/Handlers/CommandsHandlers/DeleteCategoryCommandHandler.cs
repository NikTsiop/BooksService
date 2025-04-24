using BooksService.Application.Commnands;
using BooksService.Application.Interfaces;
using MediatR;
using static BooksService.Domain.Exceptions.CategoryExceptions;

namespace BooksService.Application.Handlers.CommandsHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IBooksRepository _booksRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IBooksRepository booksRepository)
        {
            _categoryRepository = categoryRepository;
            _booksRepository = booksRepository;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // Design decision:
            // Prevent deletion if any books exist for this category.
            // This protects data integrity and invites explicit user action if cleanup is needed.

            var category = await _categoryRepository.GetByIdAsync(request.CategoryId) ??
                throw new CategoryNotFoundException();

            var books = await _booksRepository.GetByCategoryIdAsync(request.CategoryId);

            category.EnsureDeletable(books);

            await _categoryRepository.DeleteAsync(category);
        }
    }
}
