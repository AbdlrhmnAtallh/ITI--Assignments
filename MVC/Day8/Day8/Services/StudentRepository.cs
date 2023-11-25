using Day8.Models;
namespace Day8.Services
{
    public class StudentRepository : IStudentRepository
    {
        public static List<Student> Students = new List<Student>();

        Day8dbContext Context;// = new Day8dbContext();
        public StudentRepository (Day8dbContext _context)
        {
            Context = _context;
        }
        public void Add(Student student)
        {
            Context.Students.Add(student);
            Context.SaveChanges();
            Students.Add(new Student { Id = student.Id, Name = student.Name, Age = student.Age, DepartmentId = student.DepartmentId });
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
        public int Remove (int id)
        {
            var student = Context.Students.FirstOrDefault(e => e.Id == id);
            if (student != null)
            { 
                Context.Students.Remove(student);
                Context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }

}
