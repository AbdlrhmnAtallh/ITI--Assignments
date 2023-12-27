using FinalProject_HRsystem.Models.EmployeeINFO;

namespace FinalProject_HRsystem.Models.DepartmentINFO
{
    public partial class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee DepartmentHead { get; set; }
        public List<Employee> Employees { get; set; }
        public int DepartmentHeadId { get; set; }
        public Department()
        {
            // Initialize the Employees collection
            Employees = new List<Employee>();
        }
    }
}
