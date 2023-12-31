using Microsoft.AspNetCore.Mvc;
using FinalProject_HRsystem.Models.DepartmentINFO;
using FinalProject_HRsystem.Models.TaskINFO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject_HRsystem.Models.EmployeeINFO
{

    public enum GenderType
    {
        Male,
        Female,
        Robot
    }

    [ModelMetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
        // ..
    }

    public class EmployeeMetaData
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage ="Id Is Required")]
        public int Id { get; set; }
        [Required (ErrorMessage ="Name Is Required")]
        [StringLength(50 , ErrorMessage ="The Name Field Must Be a Maximum of 50 Characters")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Birth Date Is Required")]
       // [DataType(DataType.Date,ErrorMessage ="Invalid Date")]
        [Display(Name="Date Of Birth")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateOnly Birthdate { get; set; }
        [Required (ErrorMessage ="Title Is Required")]
        [StringLength(50,ErrorMessage ="Max Length is 50 Characters")]
        public string Title { get; set; }
        [Required (ErrorMessage ="Gender Is Required")]
        [EnumDataType(typeof(GenderType))]
        public string Gender { get; set; }
        [Required(ErrorMessage ="Country Field Is Required")]
        [MaxLength(50,ErrorMessage ="Max Length is 50 Characters")]
        public string Country { get; set; }
        [MaxLength(50,ErrorMessage ="Max Length is 50 Characters")]
        public string City { get; set; }
        [Required(ErrorMessage ="This Field Is Required")]
        public int GrossSalary { get; set; }
        [Required(ErrorMessage ="This Field is Required")]
        public int NetSalary { get; set; }
        [Required(ErrorMessage ="Years Of Experince Field is Required")]
        public decimal YearsOfExperince { get; set; }
        [Required(ErrorMessage ="Department Field is Required")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int TaskId { get; set; }
        public Taskk? Tasks { get; set; }
        public string? Image { get; set; }
    }
}
