namespace BooksService.Domain.Exceptions
{
    public class UserExceptions
    {
        public class DuplicateUserException : Exception
        {
            public DuplicateUserException(string message = "Duplicate User") : base(message) { }
        }
    }
}
