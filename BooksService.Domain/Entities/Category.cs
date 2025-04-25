namespace BooksService.Domain.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // A category cannot be deleted if any books exist under it
        public void EnsureDeletable(IEnumerable<Book> books)
        {
            if (books.Any())
                throw new InvalidOperationException("Cannot delete category with books assigned");
        }
    }
}
