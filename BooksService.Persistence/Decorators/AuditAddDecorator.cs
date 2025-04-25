using BooksService.Application.Interfaces.DecorateInterfaces;
using BooksService.Application.Interfaces.Services;

namespace BooksService.Persistence.Decorators
{
    internal class AuditAddDecorator<TEntity> : IAddRepository<TEntity> where TEntity : class
    {
        private readonly IAddRepository<TEntity> _inner;
        private readonly IAuditService _audit;

        public AuditAddDecorator(IAddRepository<TEntity> inner, IAuditService audit)
        {
            _inner = inner;
            _audit = audit;
        }

        public async Task<long?> AddAsync(TEntity entity)
        {
            var result = await _inner.AddAsync(entity);
            if (result is not null)
            {
                await _audit.LogAsync(
                    entityName: typeof(TEntity).Name,
                    action: "Create",
                    details: $"Created: {entity}");
            }
            return result;
        }
    }
}
