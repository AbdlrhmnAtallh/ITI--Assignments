using System.ComponentModel.DataAnnotations;

namespace FinalProject_HRsystem.Common
{
    public class InValidValueAttribute : ValidationAttribute 
    {
        public int num { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                try
                {
                    int val = (int)value;
                    if (val > num)
                    {
                        return new ValidationResult(val + " Is invalid value");
                    }
                    else
                        return ValidationResult.Success;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
                
            return ValidationResult.Success;
        }
    }

}
