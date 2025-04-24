using BooksService.Application.Interfaces.DecorateInterfaces;
using BooksService.Domain.Entities;

namespace BooksService.Application.Interfaces.Repositories
{
    public interface ICategoryRepository : IDeleteRepository<Category>
    {
        Task<Category?> GetByIdAsync(long id);
    }
}
