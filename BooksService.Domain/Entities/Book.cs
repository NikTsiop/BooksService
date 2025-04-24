namespace BooksService.Domain.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public long CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }
}
