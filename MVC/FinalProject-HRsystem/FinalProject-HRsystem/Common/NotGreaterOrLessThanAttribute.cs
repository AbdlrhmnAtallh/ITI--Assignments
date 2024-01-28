using System.ComponentModel.DataAnnotations;

namespace FinalProject_HRsystem.Common
{
    public class NotGreaterOrLessThanAttribute:ValidationAttribute
    {
        public int max { get; set; } = 5;
        public int min { get; set; } = 1;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) { return ValidationResult.Success; }
            int val = (int)value;
            if(val > max || val < min) { return new ValidationResult("Value can't be greater than " + max + " or less than " + min); }
            return ValidationResult.Success;
        }
    }
}
