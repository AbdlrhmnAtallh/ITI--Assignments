using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }

        [ForeignKey("department")]
        public int DepartmentId { get; set; }

        public Department department { get; set; }
    }
}
