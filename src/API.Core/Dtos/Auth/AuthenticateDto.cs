using System.ComponentModel.DataAnnotations;

namespace API.Core.Dtos.Auth
{
    public class AuthenticateDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}