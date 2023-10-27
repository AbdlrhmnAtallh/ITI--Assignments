
using System.ComponentModel.DataAnnotations;

namespace Day7.Models
{
    public class Validations:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
       {
            string Value = (string)value;
            if (Value == "Cairo" || Value == "Alexandria")
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(value + " Not Allowed");
           
        }

    }
}
