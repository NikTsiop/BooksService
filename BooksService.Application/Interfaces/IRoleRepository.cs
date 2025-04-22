using BooksService.Domain.Entities;

namespace BooksService.Application.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetByIdsAsync(List<long> ids);
    }
}
