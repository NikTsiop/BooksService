namespace BooksService.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public required ICollection<Role> Role { get; set; }
    }
}
