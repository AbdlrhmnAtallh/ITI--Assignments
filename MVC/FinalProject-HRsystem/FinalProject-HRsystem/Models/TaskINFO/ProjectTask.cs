using FinalProject_HRsystem.Models.EmployeeINFO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject_HRsystem.Models.TaskINFO
{
    public partial class ProjectTask
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        // i want to make a counter to count the characters left to end the 500 characters
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DueDate { get; set; }

        public bool IsCompleted { get; set; }

        public int Priority { get; set; }

        public List<Employee> Employees { get; set; }
        public Employee TaskLeader { get; set; }


        // Additional properties can be added here

        // Constructor
        public ProjectTask()
        {
            CreatedAt = DateTime.Now;
            IsCompleted = false;
            Employees = new List<Employee>();
        }
    }
}
