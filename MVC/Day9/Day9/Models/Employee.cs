using System.ComponentModel.DataAnnotations.Schema;

namespace Day9.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
