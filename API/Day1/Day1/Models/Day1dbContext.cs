namespace Day1.Models
{
    public class Day1dbContext
    {
        public static List<Employee> Employees { get; set; }
        
        public Day1dbContext()
        {
            Employee item = new Employee();
            item.Id = 1; item.Name = "A"; item.salary = 100;
            Employees.Add(item);
        }
    }
}
