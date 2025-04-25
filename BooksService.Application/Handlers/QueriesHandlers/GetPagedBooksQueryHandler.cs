using BooksService.Application.DTO;
using BooksService.Application.Interfaces.Repositories;
using BooksService.Application.Mapper;
using BooksService.Application.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BooksService.Application.Handlers.QueriesHandlers
{
    public class GetPagedBooksQueryHandler: IRequestHandler<GetPagedBooksQuery, PagedResult<BookDTO>>
    {
        private readonly IBooksRepository _booksRepository;
        private readonly ILogger<GetPagedBooksQueryHandler> _logger;

        public GetPagedBooksQueryHandler(
            IBooksRepository booksRepository,
            ILogger<GetPagedBooksQueryHandler> logger)
        {
            _booksRepository = booksRepository;
            _logger = logger;
        }

        public async Task<PagedResult<BookDTO>> Handle(GetPagedBooksQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetPagedBooksQuery with pageNumber: {pageNumber} and pageSize: {pageSize}",
                request.pageNumber,
                request.pageSize
            );

            var totalCount = await _booksRepository.CountBooksAsync();
            var books = await _booksRepository.GetPagedAsync(request.pageNumber, request.pageSize);

            return new PagedResult<BookDTO>
            {
                Items = CreateMapper.Mapper.Map<List<BookDTO>>(books),
                TotalCount = totalCount,
                PageNumber = request.pageNumber,
                PageSize = request.pageSize
            };
        }
    }
}
