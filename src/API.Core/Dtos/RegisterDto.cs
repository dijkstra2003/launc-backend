using System.ComponentModel.DataAnnotations;
using API.Core.Validators;

namespace API.Core.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [Password]
        public string Password { get; set; }
    }
}