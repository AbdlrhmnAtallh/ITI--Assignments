using Day8.Models;
namespace Day8.Services
{
    public class StudentRepository
    {
        public static List<Student> Students = new List<Student>();
        public void Add(Student student)
        {
            Students.Add(new Student { Id=student.Id,Name=student.Name,Age=student.Age,DepartmentId=student.DepartmentId});
        }
        public List<Student> All()
        {
            var d = Students.ToList();
            return d;
        }
    }
}
