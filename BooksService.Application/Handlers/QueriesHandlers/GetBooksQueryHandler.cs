using BooksService.Application.DTO;
using BooksService.Application.Interfaces.Repositories;
using BooksService.Application.Mapper;
using BooksService.Application.Queries;
using MediatR;

namespace BooksService.Application.Handlers.QueriesHandlers
{
    public class GetBooksQueryHandler: IRequestHandler<GetBooksQuery, PagedResult<BookDTO>>
    {
        private readonly IBooksRepository _booksRepository;

        public GetBooksQueryHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<PagedResult<BookDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
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
