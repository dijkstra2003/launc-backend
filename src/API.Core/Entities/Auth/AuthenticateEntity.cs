using System.ComponentModel.DataAnnotations;

namespace API.Core.Entities.Auth
{
    public class AuthenticateEntity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}