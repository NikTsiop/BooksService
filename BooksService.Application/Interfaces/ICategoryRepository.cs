using BooksService.Domain.Entities;

namespace BooksService.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(long id);
        Task DeleteAsync(Category category);
    }
}
