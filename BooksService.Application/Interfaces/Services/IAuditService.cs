using BooksService.Infrastructure.Entities;

namespace BooksService.Application.Interfaces.Services
{
    public interface IAuditService
    {
        Task LogAsync(string entityName, string action, string? details = null);
    }
}
