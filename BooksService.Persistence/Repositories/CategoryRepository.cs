using BooksService.Application.Interfaces.Repositories;
using BooksService.Domain.Entities;

namespace BooksService.Persistence.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {

        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category?> GetByIdAsync(long id)
        {
            return await _context.Categories.FindAsync(id);
        }
    }
}
