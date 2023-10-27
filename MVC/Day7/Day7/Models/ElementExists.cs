using System.ComponentModel.DataAnnotations;

namespace Day7.Models
{
    public class ElementExists:ValidationAttribute
    {
        protected override ValidationResult IsValid (object value,ValidationContext validationContext)
        {
            Employee e = validationContext.ObjectInstance as Employee;
            //var x = Employee.Employees.Find(i => i.Id == e.Id);
            foreach(var i in Employee.Employees)
            {
                if (e==i)
                {
                    return new ValidationResult("This item already exists");
                }
            }
                return ValidationResult.Success;
        }
    }
}
