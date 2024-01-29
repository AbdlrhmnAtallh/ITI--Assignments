using FinalProject_HRsystem.Models.EmployeeINFO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using FinalProject_HRsystem.Common;

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
        [NoNumbers]
        [Required(ErrorMessage ="Task name is required")]
        [Display(Name="Task Name")]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Display(Name="Created at")]
        [Required(ErrorMessage ="Creating Time is required")]
        public DateTime CreatedAt { get; set; }
        [Display(Name="Dead Line")]
        [Required(ErrorMessage="Dead Line is required")]
        [DeadLineNotGreaterThanCreatingTime]
        public DateTime DueDate { get; set; }
        [Required(ErrorMessage="Task Status is Required")]
        [Display(Name="Task Status")]
        public bool IsCompleted { get; set; }

        [Required(ErrorMessage ="Task Priority is required")]
        [NotGreaterOrLessThan(max =5,min =1 )]
        public int Priority { get; set; }

        [Required(ErrorMessage ="Task Leader feild is required")]
        [Display(Name="Task Leader")]
        public int TaskLeader { get; set; }
        [Required(ErrorMessage ="Employees works on Task feild is required")]
        public List<int> Employees { get; set; }
    }
}
