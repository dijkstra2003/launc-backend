using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        User Authenticate(string email, string password);
        Task<EntityEntry<User>> RegisterAsync(string email, string password, string name);
        List<User> GetAll();
        Task<List<User>> GetAllAsync();
        User Find(int id);
        Task<User> FindAsync(int id);
        User FindByIdentity(ClaimsIdentity identity);
        Task<User> FindByIdentityAsync(ClaimsIdentity identity);
        bool EmailIsUnique(string email);
    }

    [System.Serializable]
    public class UserAuthenticateException : Exception
    {
        public UserAuthenticateException(string message) : base(message) { }
        public UserAuthenticateException(string message, System.Exception inner) : base(message, inner) { }
        protected UserAuthenticateException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
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

        public User Authenticate(string email, string password)
        {
            var user = _ctx.Users.SingleOrDefault(x => x.Email.ToLower() == email.ToLower());

            if (!UserExists(user))
                throw new UserAuthenticateException("User not found");

            if (!ValidatePassword(password, user.Password))
                throw new UserAuthenticateException("User credentials do not match");

            return user;
        }

        public async Task<EntityEntry<User>> RegisterAsync(
            string email,
            string password,
            string name
        ) {
            var user = _ctx.Users.Add(new User {
                Email = email,
                Password = HashPassword(password),
                Name = name
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

        public User Find(int id)
        {
            return _ctx.Users.Find(id);
        }

        public async Task<User> FindAsync(int id)
        {
            return await _ctx.Users.FindAsync(id);
        }

        public User FindByIdentity(ClaimsIdentity identity)
        {
            return Find(GetIdFromIdentity(identity));
        }

        public Task<User> FindByIdentityAsync(ClaimsIdentity identity)
        {
            return FindAsync(GetIdFromIdentity(identity));
        }

        private int GetIdFromIdentity(ClaimsIdentity identity)
        {
            return int.Parse(identity.FindFirst(ClaimTypes.Name).Value);
        }

        public bool EmailIsUnique(string email)
        {
            return !_ctx.Users.Any(x => x.Email.ToLower() == email.ToLower());
        }

        private bool UserExists(User user)
        {
            return user != null;
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