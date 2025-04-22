using BooksService.Api.Mapper;
using BooksService.Api.Responses;
using BooksService.Application.DTO;
using BooksService.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BooksService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/get-paged-books")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPagedBooks([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetBooksQuery { pageNumber = pageNumber, pageSize = pageSize });
            var resultMapped = CreateMapper.Mapper.Map<PagedResponse<BookDTO>>(result);
            return Ok(resultMapped);
        }

        [HttpGet]
        [Route("/get-all-books")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());
            return Ok( new BooksResponse {  Books = result } );
        }

    }
}
