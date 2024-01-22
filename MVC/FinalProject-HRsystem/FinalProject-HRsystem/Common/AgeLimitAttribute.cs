using System.ComponentModel.DataAnnotations;

namespace FinalProject_HRsystem.Common
{
    public class AgeLimitAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) { return ValidationResult.Success; }

            DateOnly EmployeeDOF =(DateOnly)value;
            if (EmployeeDOF.AddYears(60)<DateOnly.FromDateTime(DateTime.Today))
            {
                return new ValidationResult("The" +
                    " date of birth provided indicates that the employee" +
                    " is older than 60 years." +
                    " Please ensure the date of birth is accurate" +
                    " and reflects an age within the accepted limit.");
            }
            return ValidationResult.Success;

        }
    }
}
