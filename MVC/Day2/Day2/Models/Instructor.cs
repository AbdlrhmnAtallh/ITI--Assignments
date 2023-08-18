using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Img { get; set; }
        public int Salary { get; set; }
        public string? Adrress { get; set; }

        [ForeignKey("department")]
        public int DepartmentId { get; set; }
        public Department department { get; set; }

        [ForeignKey("course")]
        public int CourseId { get; set; }
        public Course course { get; set; }
    }
}
