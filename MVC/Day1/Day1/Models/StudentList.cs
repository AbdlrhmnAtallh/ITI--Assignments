using System.Collections.Generic;
namespace Day1.Models
    
{
    public static  class StudentList
    {
        public static List<Student> Students { get; set; }
        static StudentList()
        {
            Students = new List<Student>();
            Students.Add(new Student() { Id = 1 , Name="StudentA",Address="AddressA",Image= "StudentC.jpg" });
            Students.Add(new Student() { Id = 2 , Name="StudentB",Address="AddressB",Image= "StudentC.jpg" });
            Students.Add(new Student() { Id = 3 , Name="StudentC",Address="AddressC",Image= "StudentC.jpg" });
            
        }
    }
}
