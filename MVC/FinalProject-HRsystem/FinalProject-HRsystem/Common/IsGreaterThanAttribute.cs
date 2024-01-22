using FinalProject_HRsystem.Models.EmployeeINFO;
using System.ComponentModel.DataAnnotations;
namespace FinalProject_HRsystem.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IsGreaterThanAttribute : ValidationAttribute
    {
        public string CompareProp { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(CompareProp);

            if (property != null)
            {
                var compareValue = (int)property.GetValue(validationContext.ObjectInstance);

                if ((int)value >= compareValue)
                {
                    return new ValidationResult("Ca");
                }
            }
            return ValidationResult.Success;
        }
    }
}
