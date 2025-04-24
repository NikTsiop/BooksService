using BooksService.Application.Interfaces.Services;
using BooksService.Infrastructure.Entities;
using BooksService.Persistence;

namespace BooksService.Infrastructure.Services
{
    internal class AuditService : IAuditService
    {
        private readonly AppDbContext _context;

        public AuditService(AppDbContext context)
        {
            _context = context;
        }

        public async Task LogAsync(string entityName, string action, string? details = null)
        {
            var log = new AuditLog
            {
                Id = Guid.NewGuid(),
                EntityName = entityName,
                Action = action,
                Timestamp = DateTime.UtcNow,
                Details = details
            };

            _context.AuditLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
