using BooksService.Domain.Entities;

namespace BooksService.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(User user);
        Task<User?> FindByUserInfo(User user);
    }
}
