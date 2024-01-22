using System.ComponentModel.DataAnnotations.Schema;
using FinalProject_HRsystem.Models.DepartmentINFO;
using FinalProject_HRsystem.Models.TaskINFO;
namespace FinalProject_HRsystem.Models.EmployeeINFO
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Birthdate { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int GrossSalary { get; set; }
        public int NetSalary { get; set; }
        public int YearsOfExperince { get;set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public Taskk? Tasks { get; set; }
        public string? Image { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
