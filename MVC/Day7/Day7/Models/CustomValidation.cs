using System.ComponentModel.DataAnnotations;

namespace Day7.Models
{
    public class CSV:ValidationAttribute
    {
        public int n { get; set; } = 18;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int age = int.Parse(value.ToString());
            if (age > n)
            {
                // success
                return ValidationResult.Success;
            }
            return new ValidationResult("Age must be over 30 ");
        }
    }
}
