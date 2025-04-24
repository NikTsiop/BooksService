using BooksService.Application.Commnands;
using FluentValidation;

namespace BooksService.Application.Validators.CommandValidators
{
    internal class CreateUserCommnadValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommnadValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name should not be empty.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname should not be empty.");
        }
    }
}
