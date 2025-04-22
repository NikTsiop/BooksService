using BooksService.Domain.Entities;

namespace BooksService.Persistence
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var category1 = new Category { Name = "Science" };
                var category2 = new Category { Name = "Literature" };

                var books = new List<Book>
                {
                    new Book { Title = "To Kill a Mockingbird", Category = "Fiction" },
                    new Book { Title = "1984", Category = "Dystopian" },
                    new Book { Title = "Pride and Prejudice", Category = "Romance" },
                    new Book { Title = "The Great Gatsby", Category = "Classic" },
                    new Book { Title = "Moby Dick", Category = "Adventure" },
                    new Book { Title = "War and Peace", Category = "Historical" },
                    new Book { Title = "The Hobbit", Category = "Fantasy" },
                    new Book { Title = "Brave New World", Category = "Sci-Fi" },
                    new Book { Title = "The Catcher in the Rye", Category = "Coming-of-Age" },
                    new Book { Title = "Crime and Punishment", Category = "Psychological" },
                    new Book { Title = "The Alchemist", Category = "Philosophical" },
                    new Book { Title = "The Lord of the Rings", Category = "Fantasy" },
                    new Book { Title = "Harry Potter and the Sorcerer's Stone", Category = "Fantasy" },
                    new Book { Title = "Frankenstein", Category = "Horror" },
                    new Book { Title = "Dracula", Category = "Horror" },
                    new Book { Title = "Jane Eyre", Category = "Gothic" },
                    new Book { Title = "Wuthering Heights", Category = "Drama" },
                    new Book { Title = "The Odyssey", Category = "Epic" },
                    new Book { Title = "Don Quixote", Category = "Satire" },
                    new Book { Title = "Les Misérables", Category = "Historical" },
                };

                var roleAdmin = new Role { RoleName = "Admin", Users = new List<User>() };
                var roleUser = new Role { RoleName = "User", Users = new List<User>() };

                var user1 = new User { FirstName = "Alice", Surname = "Smith", Role = new List<Role> { roleAdmin } };
                var user2 = new User { FirstName = "Bob", Surname = "Johnson", Role = new List<Role> { roleUser } };

                context.Users.AddRange(user1, user2);
                context.Roles.AddRange(roleAdmin, roleUser);
                context.Categories.AddRange(category1, category2);
                context.Books.AddRange(books);

                context.SaveChanges();

            }
        }
    }
}
