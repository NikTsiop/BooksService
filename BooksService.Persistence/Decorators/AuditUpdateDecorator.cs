using BooksService.Application.Interfaces.DecorateInterfaces;
using BooksService.Application.Interfaces.Services;

namespace BooksService.Persistence.Decorators
{
    internal class AuditUpdateDecorator<TEntity> : IUpdateRepository<TEntity> where TEntity : class
    {

        private readonly IUpdateRepository<TEntity> _inner;
        private readonly IAuditService _audit;

        public AuditUpdateDecorator(IUpdateRepository<TEntity> inner, IAuditService audit)
        {
            _inner = inner;
            _audit = audit;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _inner.UpdateAsync(entity);
            await _audit.LogAsync(
                entityName: typeof(TEntity).Name,
                action: "Update",
                details: $"Updated: {entity}"
             );
        }
    }
}
