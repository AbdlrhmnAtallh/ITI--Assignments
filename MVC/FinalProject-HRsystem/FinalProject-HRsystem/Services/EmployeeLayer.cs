using FinalProject_HRsystem.Models.EmployeeINFO;
namespace FinalProject_HRsystem.Services
{
    public class EmployeeLayer : IEmployeeLayer
    {
        private List<Employee> Employees = new List<Employee>();

        public void Add(Employee employee)
        {
            Employees.Add(employee);
        }
        public List<Employee> All()
        {
            return Employees;
        }
        public int Update(Employee employee)
        {
            var item = Employees.FirstOrDefault(e => e.Id == employee.Id);
            
            if (item == null)
            {
                return 0;
            }

            item.Name = employee.Name;
            item.Birthdate = employee.Birthdate;
            item.City = employee.City;
            item.Country = employee.Country;
            item.DepartmentId = employee.DepartmentId;
            item.GrossSalary = employee.GrossSalary;
            item.NetSalary = employee.NetSalary;
            item.TaskId = employee.TaskId;
            item.YearsOfExperince = employee.YearsOfExperince;
            item.Title=employee.Title;
            item.Image=employee.Image;

            return 1;
        }
        public Employee? GetAnEmployee(int id)
        {
            var item = Employees.FirstOrDefault(e => e.Id == id);
            if (item == null)
            {
                return null;
            }
            return item;
        }
        public int Delete(int id)
        {
            var employee = Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return 0;
            }
            Employees.Remove(employee);
            return 1;
        }
        public int DeleteAll()
        {
            if (Employees.Count == 0)
            {
                return 0;
            }
            Employees.RemoveRange(0, Employees.Count);
            return 1;
        }
    }
}
