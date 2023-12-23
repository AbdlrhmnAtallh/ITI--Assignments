﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject_HRsystem.Models.Employee
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
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date,ErrorMessage ="Invalid")]
        [Display(Name="Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
            ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [EnumDataType(typeof(GenderType))]
        public string Gender { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        public int GrossSalary { get; set; }
        public int NetSalary { get; set; }
        public decimal YearsOfExperince { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int TaskId { get; set; }
        public Tasks Tasks { get; set; }
        public string Image { get; set; }
    }
}
