using BooksService.Domain.Entities;

namespace BooksService.Persistence
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Id = 1, Name = "Fiction" },
                    new Category { Id = 2, Name = "Dystopian" },
                    new Category { Id = 3, Name = "Romance" },
                    new Category { Id = 4, Name = "Classic" },
                    new Category { Id = 5, Name = "Adventure" },
                    new Category { Id = 6, Name = "Historical" },
                    new Category { Id = 7, Name = "Fantasy" },
                    new Category { Id = 8, Name = "Sci-Fi" },
                    new Category { Id = 9, Name = "Coming-of-Age" },
                    new Category { Id = 10, Name = "Psychological" },
                    new Category { Id = 11, Name = "Philosophical" },
                    new Category { Id = 12, Name = "Horror" },
                    new Category { Id = 13, Name = "Gothic" },
                    new Category { Id = 14, Name = "Drama" },
                    new Category { Id = 15, Name = "Epic" },
                    new Category { Id = 16, Name = "Satire" },
                    new Category { Id = 17, Name = "Biography" },
                    new Category { Id = 18, Name = "Self-Help" },
                    new Category { Id = 19, Name = "Cooking" },
                    new Category { Id = 20, Name = "Travel" },
                    new Category { Id = 21, Name = "Science" },
                    new Category { Id = 22, Name = "Art" },
                    new Category { Id = 23, Name = "Music" },
                    new Category { Id = 24, Name = "Religion" },
                    new Category { Id = 25, Name = "Business" }
                };

                var books = new List<Book>
                {
                    new Book { Title = "To Kill a Mockingbird", CategoryId = 1 },
                    new Book { Title = "1984", CategoryId = 2 },
                    new Book { Title = "Pride and Prejudice", CategoryId = 3 },
                    new Book { Title = "The Great Gatsby", CategoryId = 4 },
                    new Book { Title = "Moby Dick", CategoryId = 5 },
                    new Book { Title = "War and Peace", CategoryId = 6 },
                    new Book { Title = "The Hobbit", CategoryId = 7 },
                    new Book { Title = "Brave New World", CategoryId = 8 },
                    new Book { Title = "The Catcher in the Rye", CategoryId = 9 },
                    new Book { Title = "Crime and Punishment", CategoryId = 10 },
                    new Book { Title = "The Alchemist", CategoryId = 11 },
                    new Book { Title = "The Lord of the Rings", CategoryId = 7 },
                    new Book { Title = "Harry Potter and the Sorcerer's Stone", CategoryId = 7 },
                    new Book { Title = "Frankenstein", CategoryId = 12 },
                    new Book { Title = "Dracula", CategoryId = 12 },
                    new Book { Title = "Jane Eyre", CategoryId = 13 },
                    new Book { Title = "Wuthering Heights", CategoryId = 14 },
                    new Book { Title = "The Odyssey", CategoryId = 15 },
                    new Book { Title = "Don Quixote", CategoryId = 16 },
                    new Book { Title = "Les Misérables", CategoryId = 6 }
                };

                var roles = new List<Role>
                {
                    new Role { Id = 1, RoleName = "Admin", Users = [] },
                    new Role { Id = 2, RoleName = "User", Users = [] },
                    new Role { Id = 3, RoleName = "Moderator", Users = [] },
                    new Role { Id = 4, RoleName = "Editor", Users = [] },
                    new Role { Id = 5, RoleName = "Viewer", Users = [] },
                    new Role { Id = 6, RoleName = "Author", Users = [] },
                    new Role { Id = 7, RoleName = "Manager", Users = [] },
                    new Role { Id = 8, RoleName = "Guest", Users = [] },
                    new Role { Id = 9, RoleName = "Support", Users = [] },
                    new Role { Id = 10, RoleName = "Developer", Users = [] }
                };

                var user1 = new User { FirstName = "Alice", Surname = "Smith", Role = new List<Role> { roles[0], roles[7] } };
                var user2 = new User { FirstName = "Bob", Surname = "Johnson", Role = new List<Role> { roles[4], roles[9] } };

                context.Users.AddRange(user1, user2);
                context.Roles.AddRange(roles);
                context.Categories.AddRange(categories);
                context.Books.AddRange(books);

                context.SaveChanges();

            }
        }
    }
}
