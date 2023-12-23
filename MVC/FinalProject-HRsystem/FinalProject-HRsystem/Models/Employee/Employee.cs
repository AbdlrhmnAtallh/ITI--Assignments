﻿using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject_HRsystem.Models.Employee
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int GrossSalary { get; set; }
        public int NetSalary { get; set; }
        public decimal YearsOfExperince { get;set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [ForeignKey("Tasks")]
        public int TaskId { get; set; }
        public Tasks Tasks { get; set; }
        public string Image { get; set; }

    }
}
