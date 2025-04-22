using MediatR;

namespace BooksService.Application.Commnands
{
    public class UpdateUserRoleCommand: IRequest
    {
        public long UserId { get; set; }
        public List<long> RoleIds { get; set; } = [];
    }
}
