namespace BooksService.Domain.Exceptions
{
    public class UserExceptions
    {
        public class DuplicateUserException : Exception
        {
            public DuplicateUserException(string message = "Duplicate User") : base(message) { }
        }

        public class UserNotFoundException : Exception
        {
            public UserNotFoundException(string message = "User not found") : base(message) { }
        }
    }
}
