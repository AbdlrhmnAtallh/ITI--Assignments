using FinalProject_HRsystem.Models.EmployeeINFO;
namespace FinalProject_HRsystem.Services
{
    public class EmployeeLayer : IEmployeeLayer
    {
        public static List<Employee> Employees = new List<Employee>();

        public EmployeeLayer()
        {
            Employees.Add(
                new Employee
                {
                    Id = 1,
                    Name = "Abdelrhman",
                    Birthdate = new DateTime(2001, 8, 25),
                    City = "Alexandria",
                    Country = "Egypt",
                    Gender = "Male",
                    GrossSalary = 10000,
                    NetSalary = 9000,
                    DepartmentId = 1,
                    Title = "Software Engineer",
                    YearsOfExperince = 1,
                    TaskId = 1
                });
            Employees.Add(
                new Employee
                {
                    Id = 2,
                    Name = "Tony",
                    Birthdate = new DateTime(2000, 2, 3),
                    City = "London",
                    Country = "UK",
                    Gender = "Male",
                    GrossSalary = 9000,
                    NetSalary = 7000,
                    DepartmentId = 1,
                    Title = "Web Developer",
                    YearsOfExperince = 3,
                    TaskId = 1
                });
            Employees.Add(
                new Employee
                {
                    Id = 3,
                    Name = "Sophia",
                    Birthdate = new DateTime(1998, 4, 10),
                    City = "Bercalona",
                    Country = "Spain",
                    Gender = "Female",
                    GrossSalary = 8000,
                    NetSalary = 8000,
                    DepartmentId = 2,
                    Title = "Seals",
                    YearsOfExperince = 4,
                    TaskId = 1
                });
            Employees.Add(
                new Employee
                {
                    Id = 4,
                    Name = "Ahmed",
                    Birthdate = new DateTime(2002, 2, 3),
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
                    Id = 5,
                    Name = "Amira",
                    Birthdate = new DateTime(2001, 1, 1),
                    City = "Alexandria",
                    Country = "Egypt",
                    Gender = "Female",
                    GrossSalary = 6000,
                    NetSalary = 5500,
                    DepartmentId = 1,
                    Title = "Customer Server",
                    YearsOfExperince = 1,
                    TaskId = 2
                });
        }

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
                    item.PhoneNumber = employee.PhoneNumber;
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
                if (Employees.Count == 0)
                {
                    throw new Exception("The Employee List is Empty");
                }
                else { Employees.RemoveRange(0, Employees.Count); }
            }
            catch (Exception ex)
            {
                throw new Exception("somthing went wrong." + ex.Message);
            }
        }

        public List<Employee> Sort(List<Employee> employees)
        {
            // employees = employees.OrderBy(e=>e.Id).ToList();

            // Bubble Sort O(N^2)
            for(int i = 0; i < employees.Count; i++)
            {
                for (int j = 0; j < employees.Count; j++)
                {
                    if (employees[i].Id < employees[j].Id)
                    {
                        var temp = employees[i];
                        employees[i] = employees[j];
                        employees[j] = temp;
                    }
                }
            }

            return employees;
        }
    }
}
