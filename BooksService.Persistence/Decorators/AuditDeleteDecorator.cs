using BooksService.Application.Interfaces.DecorateInterfaces;
using BooksService.Application.Interfaces.Services;

namespace BooksService.Persistence.Decorators
{
    internal class AuditDeleteDecorator<TEntity> : IDeleteRepository<TEntity> where TEntity : class
    {

        private readonly IDeleteRepository<TEntity> _inner;
        private readonly IAuditService _audit;

        public AuditDeleteDecorator(IDeleteRepository<TEntity> inner, IAuditService audit)
        {
            _inner = inner;
            _audit = audit;
        }
        public async Task DeleteAsync(TEntity entity)
        {
            await _inner.DeleteAsync(entity);
            await _audit.LogAsync(
                entityName: typeof(TEntity).Name,
                action: "Delete",
                details: $"Deleted: {entity}");
        }
    }
}
