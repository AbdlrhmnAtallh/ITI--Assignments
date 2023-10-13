using System.ComponentModel.DataAnnotations;

namespace Day7.Models
{
    public class CSV:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int age = int.Parse(value.ToString());
            if (age > 30)
            {
                // success
                return ValidationResult.Success;
            }
            return new ValidationResult("Age must be over 30 ");
        }
    }
}
