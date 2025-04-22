using BooksService.Application.Interfaces;
using BooksService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksService.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {

        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Role>> GetByIdsAsync(List<long> ids)
        {
            return await _context.Roles
                .Where(r => ids.Contains(r.Id))
                .ToListAsync();
        }
    }
}
