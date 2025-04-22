using MediatR;

namespace BooksService.Application.Commnands
{
    public class CreateUserCommand: IRequest<bool>
    {
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

    }
}
