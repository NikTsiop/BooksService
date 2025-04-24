namespace BooksService.Application.Interfaces.DecorateInterfaces
{
    public interface IAddRepository<TEntity> where TEntity : class
    {
        Task<bool> AddAsync(TEntity entity);
    }
}
