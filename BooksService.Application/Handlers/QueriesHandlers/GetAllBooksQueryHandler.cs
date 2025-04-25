using BooksService.Application.DTO;
using BooksService.Application.Interfaces.Repositories;
using BooksService.Application.Mapper;
using BooksService.Application.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BooksService.Application.Handlers.QueriesHandlers
{
    public class GetAllBooksQueryHandler: IRequestHandler<GetAllBooksQuery, List<BookDTO>>
    {
        private readonly IBooksRepository _booksRepository;
        private readonly ILogger<GetAllBooksQueryHandler> _logger;

        public GetAllBooksQueryHandler(
            IBooksRepository  booksRepository,
            ILogger<GetAllBooksQueryHandler> logger)
        {
            _booksRepository = booksRepository;
            _logger = logger;
        }

        public async Task<List<BookDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetAllBooksQuery");

            var books = await _booksRepository.GetAllAsync();

            return CreateMapper.Mapper.Map<List<BookDTO>>(books);
        }
    }
}
