using BooksService.Application.Commnands;
using FluentValidation;

namespace BooksService.Application.Validators.CommandValidators
{
    internal class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().NotNull().WithMessage("CategoryId should not be empty or null");
        }
    }
}
