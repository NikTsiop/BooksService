namespace BooksService.Application.Interfaces.DecorateInterfaces
{
    public interface IUpdateRepository<TEntity> where TEntity : class
    {
        Task UpdateAsync(TEntity entity);
    }
}
