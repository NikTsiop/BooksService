using BooksService.Application.DTO;
using MediatR;

namespace BooksService.Application.Queries
{
    public class GetPagedBooksQuery: IRequest<PagedResult<BookDTO>>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
