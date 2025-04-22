using BooksService.Application.DTO;
using BooksService.Application.Interfaces;
using BooksService.Application.Mapper;
using BooksService.Application.Queries;
using MediatR;

namespace BooksService.Application.Handlers.QueriesHandlers
{
    public class GetAllBooksQueryHandler: IRequestHandler<GetAllBooksQuery, List<BookDTO>>
    {
        private readonly IBooksRepository _booksRepository;

        public GetAllBooksQueryHandler(IBooksRepository  booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<List<BookDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _booksRepository.GetAllAsync();

            return CreateMapper.Mapper.Map<List<BookDTO>>(books);
        }
    }
}
