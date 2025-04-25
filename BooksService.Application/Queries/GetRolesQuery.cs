using BooksService.Application.DTO;
using MediatR;

namespace BooksService.Application.Queries
{
    public class GetRolesQuery: IRequest<List<RoleDTO>> { }
}
