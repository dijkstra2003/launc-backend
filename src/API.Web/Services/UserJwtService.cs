using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Core.Entities;
using API.Infrastructure.Data;
using API.Web.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Web.Services
{
    public interface IUserJwtService
    {
        string CreateJwt(User user);
    }
    
    public class UserJwtService : IUserJwtService
    {
        private readonly DataContext _ctx;
        private readonly AppSettings _appSettings;

        public UserJwtService(DataContext ctx, IOptions<AppSettings> appSettings)
        {
            _ctx = ctx;
            _appSettings = appSettings.Value;       
        }

        public string CreateJwt(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}