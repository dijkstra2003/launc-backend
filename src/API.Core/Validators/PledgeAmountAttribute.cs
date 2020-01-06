using System.ComponentModel.DataAnnotations;

namespace API.Core.Validators
{
    public class PledgeAmountAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!decimal.TryParse((string) value, out decimal amount))
                return new ValidationResult("Value cannot be converted to a decimal");

            if (amount < 0)
                return new ValidationResult("Pledge may not be negative");

            return ValidationResult.Success;
        }
    }
}
