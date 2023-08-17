using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }

        [ForeignKey("course")]
        public int CourseId { get; set; }
        public Course course { get; set; }

        [ForeignKey("trainee")]
        public int TraineeId { get; set; }
        public Trainee trainee { get; set; }
    }
}
