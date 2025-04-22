using BooksService.Application.DTO;
using BooksService.Domain.Entities;
using MediatR;

namespace BooksService.Application.Queries
{
    public class GetBooksQuery: IRequest<PagedResult<BookDTO>>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
