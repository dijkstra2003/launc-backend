using System.ComponentModel.DataAnnotations;

namespace API.Core.Validators
{
    public class PledgeAmountAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var amount = (decimal) value; 

            if (amount < 0)
                return new ValidationResult("Pledge may not be negative");

            return ValidationResult.Success;
        }
    }
}
