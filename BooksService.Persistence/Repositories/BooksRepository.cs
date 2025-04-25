using BooksService.Application.Interfaces.Repositories;
using BooksService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksService.Persistence.Repositories
{
    internal class BooksRepository: IBooksRepository
    {
        private readonly AppDbContext _context;

        public BooksRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetPagedAsync(int pageNumber = 1, int pageSize = 10)
        {
            return await _context.Books
                .OrderBy(b => b.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<int> CountBooksAsync()
        {
            return await _context.Books.CountAsync();
        }

        public async Task<List<Book>> GetByCategoryIdAsync(long categoryId)
        {
            return await _context.Books
                .Where(b => b.CategoryId == categoryId)
                .ToListAsync();
        }
    }
}
