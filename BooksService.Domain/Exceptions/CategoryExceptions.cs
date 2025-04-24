namespace BooksService.Domain.Exceptions
{
    public class CategoryExceptions
    {
        public class CategoryNotFoundException: Exception
        {
            public CategoryNotFoundException(string message = "Category not found") : base(message) { }
        }
    }
}
