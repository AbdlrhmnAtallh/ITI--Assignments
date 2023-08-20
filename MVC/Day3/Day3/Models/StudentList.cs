namespace Day3.Models
{
    public class StudentList
    {
        public static List<Student> StudentsList { get; set; }

       static StudentList()
        {
            StudentsList = new List<Student>();

            StudentsList.Add(new Student() { Id = 1, Name = "StudentListA" });
            StudentsList.Add(new Student() { Id = 2, Name = "StudentListB" });
            StudentsList.Add(new Student() { Id = 3, Name = "StudentListC" });

            
        }
    }
}
