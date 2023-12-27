using FinalProject_HRsystem.Models.DepartmentINFO;

namespace FinalProject_HRsystem.Services
{
    public interface IDepartmentLayer
    {
        int Add(Department department);
        void Remove(int id);
        void Update(Department department);
        public bool IsEmpty();
        public List<Department> All();
    }
}