using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int Grade { get; set; }
        public string Adrress { get; set; }

        [ForeignKey("department")]
        public int DepartmentId { get; set; }
        public Department department { get; set; }
    }
}
