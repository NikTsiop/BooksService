namespace BooksService.Application.DTO
{
    public class BookDTO
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
