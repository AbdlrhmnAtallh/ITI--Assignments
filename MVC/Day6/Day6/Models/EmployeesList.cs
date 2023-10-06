namespace Day6.Models
{
    public class EmployeesList
    {
        public  List<Employee> EmployeeList = new List<Employee>();

       public EmployeesList()
        {
            EmployeeList.Add(new Employee { Id = 1 , Name="EmployeeA",Dept=3});
            EmployeeList.Add(new Employee { Id = 2 , Name="EmployeeB",Dept=1});
            EmployeeList.Add(new Employee { Id = 3 , Name="EmployeeC",Dept=2});
            EmployeeList.Add(new Employee { Id = 4 , Name="EmployeeD",Dept=2});
        }
    }
}
