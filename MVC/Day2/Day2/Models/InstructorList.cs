namespace Day2.Models
{
    public class InstructorList
    {
        public static List<Instructor> instructorsList { get; set; }

        static InstructorList()
        {
            instructorsList = new List<Instructor>()
            {
                new Instructor() {Id = 1,Name="Instructorone",Salary=8000,DepartmentId=1,CourseId=1},
                new Instructor() {Id = 2,Name="InstructorTwo",Salary=9000,DepartmentId=2,CourseId=2},
                new Instructor() {Id = 3,Name="InstructorThree",Salary=10000,DepartmentId=3,CourseId=3},
            };
        }
    }
}
