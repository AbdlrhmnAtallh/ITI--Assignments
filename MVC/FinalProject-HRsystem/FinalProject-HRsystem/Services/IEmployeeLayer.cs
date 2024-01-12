using FinalProject_HRsystem.Models.EmployeeINFO;

namespace FinalProject_HRsystem.Services
{
    public interface IEmployeeLayer
    {
        void Add(Employee employee);
        List<Employee> All();
        void Delete(int id);
        void DeleteAll();
        Employee? GetAnEmployee(int id);
        void Update(Employee employee);
        public void Fill();
        public List<Employee> Sort(List<Employee> employees);
    }
}