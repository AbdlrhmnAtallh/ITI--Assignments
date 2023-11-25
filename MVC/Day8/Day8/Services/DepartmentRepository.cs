using Day8.Models;

namespace Day8.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        Day8dbContext Context;//= new Day8dbContext();
        public DepartmentRepository (Day8dbContext _Context)
        {
            Context = _Context;
        }
        public void Add(Department department)
        {
            Context.Departments.Add(department);
            Context.SaveChanges();
        }
        public List<Department> All()
        {
            return Context.Departments.ToList();
        }
    }
}
