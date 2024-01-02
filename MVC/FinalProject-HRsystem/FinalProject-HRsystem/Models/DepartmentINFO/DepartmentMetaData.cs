using FinalProject_HRsystem.Models.EmployeeINFO;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject_HRsystem.Models.DepartmentINFO
{
    [ModelMetadataType(typeof(DepartmentMetaData))]
    public partial class Department
    {
        // ..
    }
    public class DepartmentMetaData
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Obsolete("Use the DepartmentHeadId property instead.")]
        public Employee? DepartmentHead { get; set; }
        [Display(Name ="Department Leader")]
        /// There are a Relation 1:1 between Department and Leader
        /// Under Processing
        public int? DepartmentHeadId { get; set; }

    }
}
