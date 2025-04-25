using BooksService.Application.Interfaces.DecorateInterfaces;
using BooksService.Application.Interfaces.Repositories;
using BooksService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksService.Persistence.Repositories
{
    internal class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;            
        }

        public async Task<long?> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            // Retrieving the user ID after the creation
            return await _context.Users
                .Where(u => u.FirstName == user.FirstName && u.Surname == user.Surname)
                .Select(u => u.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByIdAsync(long Id)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<User?> GetByUserInfo(User user)
        {
            // Retrieve user ID based on matching FirstName and Surname
            return await _context.Users.FirstOrDefaultAsync(
                u => u.FirstName == user.FirstName && u.Surname == user.Surname);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
