using FinalProject_HRsystem.Models.EmployeeINFO;
namespace FinalProject_HRsystem.Services
{
    public class EmployeeLayer : IEmployeeLayer
    {
        public static List<Employee> Employees = new List<Employee>();

        public void Add(Employee employee)
        {
            try
            {
                Employees.Add(employee);
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Add This Employee",ex);
            }
        }
        public List<Employee> All()
        {
            return Employees;
        }
        public void Update(Employee employee)
        {
            try
            {
                var item = Employees.FirstOrDefault(e => e.Id == employee.Id);

                if (item == null)
                {
                    throw new Exception("No employee matches this ID.");
                }
                else
                {
                    item.Name = employee.Name;
                    item.Birthdate = employee.Birthdate;
                    item.City = employee.City;
                    item.Country = employee.Country;
                    item.DepartmentId = employee.DepartmentId;
                    item.GrossSalary = employee.GrossSalary;
                    item.NetSalary = employee.NetSalary;
                    item.TaskId = employee.TaskId;
                    item.YearsOfExperince = employee.YearsOfExperince;
                    item.Title = employee.Title;
                    item.Image = employee.Image;
                    item.Gender = employee.Gender;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Somthing went wrong. "+ex.Message);
            }
        }
        public Employee? GetAnEmployee(int id)
        {
            try
            {
                var item = Employees.FirstOrDefault(e => e.Id == id);
                if (item == null)
                {
                    throw new Exception("No employee matches this ID");
                }
                else
                {
                    return item;
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Somthing went wrong," + ex.Message);
            }
            
            
        }
        public void Delete(int id)
        {
            try
            {
                var employee = Employees.FirstOrDefault(e => e.Id == id);
                if (employee == null)
                {
                    throw new Exception("No employee matches this ID.");
                }
                else
                {
                    Employees.Remove(employee);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Somthing went wrong." + ex.Message);
            }
        }
        public void DeleteAll()
        {
            try
            {
                Employees.RemoveRange(0, Employees.Count);
                if (Employees.Count == 0)
                {
                    throw new Exception("The Employee List is Empty");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("somthing went wrong." + ex.Message);
            }
        }
        public void Fill()
        {
            Employees.Add(
                new Employee
                {
                    Id = 1,
                    Name = "A",
                    Birthdate = new DateOnly(2000, 2, 3),
                    City = "Cairo",
                    Country = "Egypt",
                    Gender = "Male",
                    GrossSalary = 10000,
                    NetSalary = 100,
                    DepartmentId = 1,
                    Title = "Web Developer",
                    YearsOfExperince = 3,
                    TaskId = 1
                });
            Employees.Add(
                new Employee
                {
                    Id = 2,
                    Name = "B",
                    Birthdate = new DateOnly(2000, 2, 3),
                    City = "Cairo",
                    Country = "Egypt",
                    Gender = "Male",
                    GrossSalary = 10000,
                    NetSalary = 100,
                    DepartmentId = 2,
                    Title = "Web Developer",
                    YearsOfExperince = 3,
                    TaskId = 1
                });
            Employees.Add(
                new Employee
                {
                    Id = 3,
                    Name = "C",
                    Birthdate = new DateOnly(2000, 2, 3),
                    City = "Cairo",
                    Country = "Egypt",
                    Gender = "Male",
                    GrossSalary = 10000,
                    NetSalary = 100,
                    DepartmentId = 1,
                    Title = "Web Developer",
                    YearsOfExperince = 3,
                    TaskId = 1
                });
            Employees.Add(
                new Employee
                {
                    Id = 4,
                    Name = "d",
                    Birthdate = new DateOnly(2000, 2, 3),
                    City = "Cairo",
                    Country = "Egypt",
                    Gender = "Male",
                    GrossSalary = 10000,
                    NetSalary = 100,
                    DepartmentId = 3,
                    Title = "Web Developer",
                    YearsOfExperince = 3,
                    TaskId = 1
                });
            Employees.Add(
                new Employee
                {
                    Id = 5,
                    Name = "A",
                    Birthdate = new DateOnly(2000, 2, 3),
                    City = "Cairo",
                    Country = "Egypt",
                    Gender = "Male",
                    GrossSalary = 10000,
                    NetSalary = 100,
                    DepartmentId = 4,
                    Title = "Web Developer",
                    YearsOfExperince = 3,
                    TaskId = 2
                });
        }
        public List<Employee> Sort(List<Employee> employees,string sortby)
        {
            for()
        }
    }
}
