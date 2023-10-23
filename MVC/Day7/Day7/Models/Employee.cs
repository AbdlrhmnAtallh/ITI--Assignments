using System.ComponentModel.DataAnnotations;

namespace Day7.Models
{
    public class Employee
    {
        [CSV]
        public int Id { get; set; }
        public string Name { get; set; }
        [Validations]
        public string City { get; set; }
        public int Dept { get; set; }
        
    }
}
