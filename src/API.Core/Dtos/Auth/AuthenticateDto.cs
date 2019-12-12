using System.ComponentModel.DataAnnotations;

namespace API.Core.Dtos.Auth
{
    public class AuthenticateDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}