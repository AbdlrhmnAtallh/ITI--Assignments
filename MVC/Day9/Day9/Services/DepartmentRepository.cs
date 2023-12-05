using Day9.Models;
namespace Day9.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        Day9DbContext Context;
        public DepartmentRepository(Day9DbContext _Context)
        {
            Context = _Context;
        }

        public int Add(Department department)
        {
            Context.Add(department);
            Context.SaveChanges();
            return 0;
        }

    }
}
