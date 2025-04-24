namespace BooksService.Application.Interfaces.DecorateInterfaces
{
    public interface IDeleteRepository<TEntity> where TEntity : class
    {
        Task DeleteAsync(TEntity entity);
    }
}
