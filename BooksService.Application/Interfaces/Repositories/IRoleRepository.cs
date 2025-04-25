using BooksService.Domain.Entities;

namespace BooksService.Application.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetByIdsAsync(List<long> ids);

        Task<List<Role>> GetAllAsync();
    }
}
