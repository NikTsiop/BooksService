using MediatR;

namespace BooksService.Application.Commnands
{
    public class DeleteCategoryCommand: IRequest
    {
        public long CategoryId { get; set; }
    }
}
