using System.Reflection.PortableExecutable;

namespace Day3.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static List<Instructor>InstructorList { get; set; }

         static Instructor()
        {
            InstructorList = new List<Instructor>();
            InstructorList.Add(new Instructor() { Id = 1, Name = "InstrucotrA" });
            InstructorList.Add(new Instructor() { Id = 2, Name = "InstrucotrB" });
        }

    }
}
