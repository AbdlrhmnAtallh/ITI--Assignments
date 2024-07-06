using System.ComponentModel.DataAnnotations.Schema;

namespace FirstConsumerForAPIs
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        //[ForeignKey("Department")]
        public int departmentid { get; set; }
        //public virtual Department Department { get; set; }

    }
}
