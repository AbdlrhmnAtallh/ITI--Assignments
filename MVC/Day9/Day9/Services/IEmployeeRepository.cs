using Day9.Models;

namespace Day9.Services
{
    public interface IEmployeeRepository
    {
        public int Add(Employee employee);
        public List<Employee> All();
    }
}
