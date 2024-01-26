using FinalProject_HRsystem.Models.EmployeeINFO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_HRsystem.Models.TaskINFO
{
    [ModelMetadataType(typeof(ProjectTaskMetaData))]
    public partial class ProjectTask
    {
        // ..
    }
    public class ProjectTaskMetaData
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    }
}
