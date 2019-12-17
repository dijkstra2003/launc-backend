using System.Collections.Generic;
using API.Core.Entities;
using API.Infrastructure.Data;

namespace API.Tests.Intergration.Setup
{
    public class SeedData
    {
        public static void InitializeDbForTests(DataContext ctx)
        {
            PopulateUsers(ctx);
        }

        public static void ReinitializeDbForTests(DataContext ctx)
        {
            RepopulareUsers(ctx);
        }

        public static void PopulateUsers(DataContext ctx)
        {
            ctx.Users.AddRange(GetSeedingMessages());
            ctx.SaveChanges();
        }

        private static void RepopulareUsers(DataContext ctx)
        {
            ctx.Users.RemoveRange(ctx.Users);
            PopulateUsers(ctx);
        }

        private static List<User> GetSeedingMessages()
        {
            return new List<User>()
            {
                new User() {
                    Id = 1,
                    Name = "Joey de Ruiter",
                    Password = BCrypt.Net.BCrypt.HashPassword("secret123"),
                    Email = "joey@example.com",
                },
                new User() {
                    Id = 2,
                    Name = "Luc Dijkstra",
                    Password = BCrypt.Net.BCrypt.HashPassword("secret124"),
                    Email = "luc@example.com",
                },
                new User() {
                    Id = 3,
                    Name = "Denzel Nievaart",
                    Password = BCrypt.Net.BCrypt.HashPassword("secret125"),
                    Email = "denzel@example.com",
                },
                new User() {
                    Id = 4,
                    Name = "Joshua Tromp",
                    Password = BCrypt.Net.BCrypt.HashPassword("secret126"),
                    Email = "josh@example.com",
                }
            };
        }
    }
}