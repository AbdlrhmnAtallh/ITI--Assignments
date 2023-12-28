using FinalProject_HRsystem.Models.EmployeeINFO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject_HRsystem.Models.TaskINFO
{
    public partial class Taskk
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DueDate { get; set; }

        public bool IsCompleted { get; set; }

        public int Priority { get; set; }

        public List<Employee> Employees { get; set; }

        // Additional properties can be added here

        // Constructor
        public Taskk()
        {
            CreatedAt = DateTime.Now;
            IsCompleted = false;
            Employees = new List<Employee>();
        }
    }
}
