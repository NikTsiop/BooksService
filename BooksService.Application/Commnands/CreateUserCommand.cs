using BooksService.Application.DTO;
using MediatR;

namespace BooksService.Application.Commnands
{
    public class CreateUserCommand: IRequest<UserDTO>
    {
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

    }
}
