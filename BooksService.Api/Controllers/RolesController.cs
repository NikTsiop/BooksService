using BooksService.Api.Responses;
using BooksService.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BooksService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController: ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/get-roles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _mediator.Send(new GetRolesQuery());
            return Ok(new RolesResponse { Roles = roles });
        }

    }
}
