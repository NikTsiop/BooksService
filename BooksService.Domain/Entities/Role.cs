namespace BooksService.Domain.Entities
{
    public class Role
    {
        public long Id { get; set; }
        public string RoleName { get; set; } = string.Empty;

        public required ICollection<User> Users { get; set; } = new List<User>();
    }
}
