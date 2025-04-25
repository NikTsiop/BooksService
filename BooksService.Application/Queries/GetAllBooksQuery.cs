using BooksService.Application.DTO;
using MediatR;

namespace BooksService.Application.Queries
{
    public class GetAllBooksQuery: IRequest<List<BookDTO>> { }
}
