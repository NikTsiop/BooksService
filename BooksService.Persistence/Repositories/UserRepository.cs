using BooksService.Application.Interfaces;
using BooksService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksService.Persistence.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;            
        }

        public async Task<bool> AddAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<User?> FindByUserInfo(User user)
        {
            try
            {
                var result = await _context.Users.FirstOrDefaultAsync(
                    u => u.FirstName == user.FirstName &&
                    u.Surname == user.Surname
                );

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
