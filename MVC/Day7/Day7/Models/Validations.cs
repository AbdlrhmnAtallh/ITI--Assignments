
using System.ComponentModel.DataAnnotations;

namespace Day7.Models
{
    public class Validations:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == "Cairo" || value == "Alexandria")
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(value + " Not Allowed");
           
        }

    }
}
