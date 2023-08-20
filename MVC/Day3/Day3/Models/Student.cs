namespace Day3.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Student> StudentsList { get; set; }

        static Student()
        {
            StudentsList = new List<Student>();
            StudentsList.Add(new Student() { Id = 1, Name = "StudentA" });
            StudentsList.Add(new Student() { Id = 2, Name = "StudentB" });
        }
    }
}
