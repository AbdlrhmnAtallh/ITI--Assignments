using System.ComponentModel.DataAnnotations;
using FinalProject_HRsystem.Models.TaskINFO;
namespace FinalProject_HRsystem.Common
{
    public class DeadLineNotGreaterThanCreatingTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) { return ValidationResult.Success; }
            var task = validationContext.ObjectInstance as ProjectTask;
            DateTime Dueat = (DateTime)value;
            DateTime createdat = task.CreatedAt;
            if (Dueat.Year > createdat.Year ||
                Dueat.Month > createdat.Month ||
                Dueat.Day > createdat.Day ||
                Dueat.Hour > createdat.Hour ||
                Dueat.Minute > createdat.Minute)
            {
                return new ValidationResult("DeadLine Can't be before Creating time");
            }
            return ValidationResult.Success;
        }
    }
}
