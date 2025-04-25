using BooksService.Application.Queries;
using FluentValidation;

namespace BooksService.Application.Validators.QueryValidators
{
    internal class GetPagedBooksQueryValidator: AbstractValidator<GetPagedBooksQuery>
    {
        public GetPagedBooksQueryValidator()
        {
            RuleFor(x => x.pageNumber).NotEmpty().WithMessage("Page Number should not be empty.");
            RuleFor(x => x.pageSize).NotEmpty().WithMessage("Page size should not be empty.");
        }
    }
}
