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
            try
            {
                return await _context.Books
                    .OrderBy(b => b.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Book>> GetAllAsync()
        {
            try
            {
                return await _context.Books.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CountBooksAsync()
        {
            try
            {
                return await _context.Books.CountAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Book>> GetByCategoryIdAsync(long categoryId)
        {
            return await _context.Books
                .Where(b => b.CategoryId == categoryId)
                .ToListAsync();
        }
    }
}
