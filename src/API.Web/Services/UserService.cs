using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core.Entities;
using API.Infrastructure.Data;
using API.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;

namespace API.Web.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        Task<EntityEntry<User>> RegisterAsync(string username, string password, string firstname, string lastname);
        List<User> GetAll();
        Task<List<User>> GetAllAsync();
        bool UsernameIsUnique(string username);
    }

    public class UserService : IUserService
    {
        private readonly DataContext _ctx;
        private readonly AppSettings _appSettings;

        public UserService(
            DataContext ctx,
            IOptions<AppSettings> appSettings
        ) {
            _ctx = ctx;
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string username, string password)
        {
            var user = _ctx.Users.SingleOrDefault(x => x.Username.ToLower() == username.ToLower());

            // Return null if the user is not found
            if (user == null)
                return null;

            // Return null if user is invalid
            if (!ValidatePassword(password, user.Password))
                return null;

            return user;
        }

        public async Task<EntityEntry<User>> RegisterAsync(
            string username,
            string password,
            string firstname,
            string lastname
        ) {
            var user = _ctx.Users.Add(new User {
                Username = username,
                Password = HashPassword(password),
                FirstName = firstname,
                LastName = lastname
            });

            await _ctx.SaveChangesAsync();

            return user;
        }

        public List<User> GetAll()
        {
            return _ctx.Users.ToList();
        }

        public Task<List<User>> GetAllAsync()
        {
            return _ctx.Users.ToListAsync();
        }

        public bool UsernameIsUnique(string username)
        {
            return !_ctx.Users.Any(x => x.Username.ToLower() == username.ToLower());
        }

        private bool ValidatePassword(string password, string hashedPassword) 
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        private string HashPassword(string password) 
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}