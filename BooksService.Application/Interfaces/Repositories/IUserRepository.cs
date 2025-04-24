using BooksService.Application.Interfaces.DecorateInterfaces;
using BooksService.Domain.Entities;

namespace BooksService.Application.Interfaces.Repositories
{
    public interface IUserRepository : IAddRepository<User>, IUpdateRepository<User>
    {
        Task<User?> GetByUserInfo(User user);

        Task<User?> GetByIdAsync(long Id);
    }
}
