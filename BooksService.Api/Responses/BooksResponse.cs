using BooksService.Application.DTO;

namespace BooksService.Api.Responses
{
    public class BooksResponse
    {
        public List<BookDTO> Books { get; set; } = [];
    }
}
