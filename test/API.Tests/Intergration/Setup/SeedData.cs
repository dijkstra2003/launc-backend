using API.Core.Entities;
using API.Infrastructure.Data;

namespace API.Tests.Intergration.Setup
{
    public class SeedData
    {
        public static void PopulateDb(DataContext ctx)
        {
            // Remove old data
            RemoveUsers(ctx);

            ctx.SaveChanges();

            // Populate new data
            PopulateUsers(ctx);

            ctx.SaveChanges();
        }

        private static void RemoveUsers(DataContext ctx)
        {
            var users = ctx.Users;

            foreach (var user in users)
            {
                ctx.Remove(user);
            }
        }

        private static void PopulateUsers(DataContext ctx)
        {
            ctx.Users.Add(new User() {
                Id = 1,
                Name = "Joey de Ruiter",
                Password = BCrypt.Net.BCrypt.HashPassword("secret123"),
                Email = "joey@example.com",
            });

            ctx.Users.Add(new User() {
                Id = 2,
                Name = "Luc Dijkstra",
                Password = BCrypt.Net.BCrypt.HashPassword("secret124"),
                Email = "luc@example.com",
            });

            ctx.Users.Add(new User() {
                Id = 3,
                Name = "Denzel Nievaart",
                Password = BCrypt.Net.BCrypt.HashPassword("secret125"),
                Email = "denzel@example.com",
            });

            ctx.Users.Add(new User() {
                Id = 4,
                Name = "Joshua Tromp",
                Password = BCrypt.Net.BCrypt.HashPassword("secret126"),
                Email = "josh@example.com",
            });
        }
    }
}