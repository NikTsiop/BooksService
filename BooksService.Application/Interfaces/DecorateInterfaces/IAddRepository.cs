namespace BooksService.Application.Interfaces.DecorateInterfaces
{
    public interface IAddRepository<TEntity> where TEntity : class
    {
        Task<long?> AddAsync(TEntity entity);
    }
}
