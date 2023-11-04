using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Day7.Models
{
    [ModelMetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
        //..
    }
    public class EmployeeMetaData
    {
        [CSV(n = 30)]
        [ElementExists]
        public int Id { get; set; }
        [Remote(action: "NameExists", controller: "Employee", ErrorMessage = " This item already exists ", AdditionalFields = "Id")]
        [MaxLength(10)]
        public string Name { get; set; }
        [Validations]
        [Remote(action: "CityLetters", controller: "Employee", ErrorMessage = "The number of characters cannot be less than 5")]
        public string City { get; set; }

    }
}
