using Day8.Models;

namespace Day8.Services
{
    public interface IStudentRepository
    {
        void Add(Student student);
        List<Student> All();
        void SaveD(Department d);
    }
}