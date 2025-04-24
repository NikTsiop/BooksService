using BooksService.Application.Commnands;
using FluentValidation;

namespace BooksService.Application.Validators.CommandValidators
{
    internal class UpdateUserRoleCommandValidator: AbstractValidator<UpdateUserRoleCommand>
    {
        public UpdateUserRoleCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage("UserId should not be empty.");
            RuleFor(x => x.RoleIds).NotNull().WithMessage("Roles should not be null.");
        }
    }
}
