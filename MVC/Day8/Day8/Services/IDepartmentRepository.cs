using Day8.Models;

namespace Day8.Services
{
    public interface IDepartmentRepository
    {
        void Add(Department department);
        List<Department> All();
    }
}