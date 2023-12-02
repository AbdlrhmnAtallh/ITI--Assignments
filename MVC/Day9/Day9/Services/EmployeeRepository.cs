using Day9.Models;
namespace Day9.Services
{
    public class EmployeeRepository:IEmployeeRepository
    {
        Day9DbContext Context;
        public EmployeeRepository(Day9DbContext _Context)
        {
            Context = _Context;
        }
        public int Add (Employee employee)
        {
            
            Context.Add(employee);
            Context.SaveChanges();
            return 0;
        }
        public List<Employee> All()
        {
            return Context.Employees.ToList();
        }
    }
}
