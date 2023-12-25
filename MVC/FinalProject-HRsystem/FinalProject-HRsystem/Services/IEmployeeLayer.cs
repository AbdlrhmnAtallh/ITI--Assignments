using FinalProject_HRsystem.Models.EmployeeINFO;

namespace FinalProject_HRsystem.Services
{
    public interface IEmployeeLayer
    {
        void Add(Employee employee);
        List<Employee> All();
        int Delete(int id);
        int DeleteAll();
        Employee? GetAnEmployee(int id);
        int Update(Employee employee);
    }
}