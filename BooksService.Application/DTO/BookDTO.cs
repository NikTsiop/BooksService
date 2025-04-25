namespace BooksService.Application.DTO
{
    public class BookDTO
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public long CategoryId { get; set; }
    }
}
