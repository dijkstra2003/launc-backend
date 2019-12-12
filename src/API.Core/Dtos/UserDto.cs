using System.ComponentModel.DataAnnotations;

namespace API.Core.Dtos
{
    public class UserDto
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}