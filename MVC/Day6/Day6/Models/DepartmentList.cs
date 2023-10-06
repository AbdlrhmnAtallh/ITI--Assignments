namespace Day6.Models
{
    public class DepartmentList
    {
        public  List<Department> Departments=new List<Department>();
        public DepartmentList()
        {
            Departments.Add(new Department { Id = 1, Name = "Finance" });
            Departments.Add(new Department { Id = 2, Name = "Software" });
            Departments.Add(new Department { Id = 3, Name = "Operations" });
        }
    }
}
