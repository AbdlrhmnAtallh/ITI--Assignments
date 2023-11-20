using Day8.Models;
namespace Day8.Services
{
    public class StudentRepository
    {
        public static List<Student> Students = new List<Student>();
       
        Day8dbContext Context = new Day8dbContext();
        public void Add(Student student)
        {
            Context.Students.Add(student);
            Context.SaveChanges();
            Students.Add(new Student { Id=student.Id,Name=student.Name,Age=student.Age,DepartmentId=student.DepartmentId});
        }
        public List<Student> All()
        {
            //var d = this.Context.Students.ToList();
            return Context.Students.ToList();
        }
        public void SaveD(Department d)
        {
            Context.Departments.Add(d);
        }
    }

}
