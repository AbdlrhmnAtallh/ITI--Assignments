using System.ComponentModel.DataAnnotations;

namespace Day7.Models
{
    public class ElementExists:ValidationAttribute
    {
        protected override ValidationResult IsValid (object value,ValidationContext validationContext)
        {
            Employee e = validationContext.ObjectInstance as Employee;
            var x = Employee.Employees.FirstOrDefault(i => i.Id == e.Id);
                if (x !=null)
                {
                    return new ValidationResult("This item already exists");
                }

                return ValidationResult.Success;
        }
    }
}
