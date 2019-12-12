using System.ComponentModel.DataAnnotations;
using API.Core.Validators;

namespace API.Core.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Password]
        public string Password { get; set; }
    }
}