using BooksService.Domain.Entities;

namespace BooksService.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(User user);

        Task<User?> GetByUserInfo(User user);

        Task<User?> GetByIdAsync(long Id);

        Task UpdateAsync(User user);
    }
}
