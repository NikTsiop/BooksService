using BooksService.Domain.Entities;

namespace BooksService.Application.Interfaces
{
    public interface IBooksRepository
    {
        Task<List<Book>> GetPagedAsync(int pageNumber = 1, int pageSize = 10);

        Task<int> CountBooksAsync();

        Task<List<Book>> GetAllAsync();

        Task<List<Book>> GetByCategoryIdAsync(long categoryId);
    }
}
