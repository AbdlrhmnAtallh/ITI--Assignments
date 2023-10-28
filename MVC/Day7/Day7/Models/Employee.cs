using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Day7.Models
{
    public class Employee
    {
        [CSV(n =30)]
        [ElementExists]
        public int Id { get; set; }
        [Remote (action: "NameExists", controller:"Employee",ErrorMessage = " This item already exists ")]
        public string Name { get; set; }
        [Validations]
        public string City { get; set; }
        public int Dept { get; set; }

        public static List<Employee> Employees = new List<Employee>();
    }
}
