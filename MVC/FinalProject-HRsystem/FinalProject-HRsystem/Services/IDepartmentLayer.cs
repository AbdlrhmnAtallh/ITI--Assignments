using FinalProject_HRsystem.Models.DepartmentINFO;

namespace FinalProject_HRsystem.Services
{
    public interface IDepartmentLayer
    {
        void Add(Department department);
        void Remove(int id);
        void Update(Department department);
        public bool IsEmpty();
        public List<Department> All();
        public Department GetDepartment(int id);
        
    }
}