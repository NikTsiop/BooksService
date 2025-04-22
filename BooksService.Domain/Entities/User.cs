namespace BooksService.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public required ICollection<Role> Role { get; set; } = new List<Role>();

        public void UpdateRoles(IEnumerable<Role> newRoles)
        {
            if (newRoles == null || !newRoles.Any())
                throw new ArgumentException("User must have at least one role");

            Role.Clear();
            foreach (var role in newRoles)
            {
                Role.Add(role);
            }
        }
    }
}
