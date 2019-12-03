using System.Collections.Generic;
using System.Linq;
using API.Core.Entities;
using API.Infrastructure.Data;
using API.Web.Helpers;
using Microsoft.Extensions.Options;

namespace API.Web.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
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
            var user = _ctx.Users.SingleOrDefault(x => x.Username == username);

            // Return null if the user is not found
            if (user == null)
                return null;

            // Return null if user is invalid
            if (!ValidatePassword(password, user.Password))
                return null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _ctx.Users.ToList();
        }

        public bool ValidatePassword(string password, string hashedPassword) 
        {
            return true;
        }
    }
}