using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace API.Core.Validators
{
    public class PasswordAttribute : ValidationAttribute
    {
        override protected ValidationResult IsValid(object value, ValidationContext validationContext) {
            var password = (string) value;
            
            if (password.Length < 6)
                return new ValidationResult("Password must be at least 6 characters long");

            if (!password.Any(char.IsUpper))
                return new ValidationResult("Password must contain a capitalized character");

            if (!password.Any(char.IsDigit))
                return new ValidationResult("Password must contain a number");

            if (!password.Any(char.IsLetter))
                return new ValidationResult("Password must contain a letter");

            return ValidationResult.Success;
        }
    }
}