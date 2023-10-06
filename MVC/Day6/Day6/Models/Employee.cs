using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day6.Models
{
    public class Employee
    {
        [Required(ErrorMessage ="Plaease Enter Employee Id")]
        [DisplayName("Employee Id")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Employee Name")]
        [DisplayName("Employee Name")]
        [MaxLength(50,ErrorMessage ="The Maximum Length is 50 character")]
        public string Name { get; set; }

        [Required]
        [Range(22,30)]
        public int Age { get; set; }

        [ForeignKey("Department")]
        [Required(ErrorMessage ="Please Select a Department ")]
        [DisplayName("Department")]
        public int Dept { get; set; }
        public Department Department { get; set; }
        public static List<Employee> Employees = new List<Employee>();
    }
}
