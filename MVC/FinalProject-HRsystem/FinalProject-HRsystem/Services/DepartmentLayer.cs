using FinalProject_HRsystem.Models.DepartmentINFO;
using FinalProject_HRsystem.Models.EmployeeINFO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection.Metadata.Ecma335;

namespace FinalProject_HRsystem.Services
{
    public class DepartmentLayer : IDepartmentLayer
    {
        public static List<Department> Departments = new List<Department>();
        private readonly IEmployeeLayer iemployeelayer;
        public DepartmentLayer(IEmployeeLayer iemployeelayer)
        {
            this.iemployeelayer = iemployeelayer;
        }

        public void Add(Department department)
        {
            try
            {
                Departments.Add(department);
            }
            catch(Exception ex)
            {
                throw new Exception("Somthing went wrong adding department. " + ex.Message);
            }
        }
        public void Update(Department department)
        {
            try
            {
                var item = Departments.FirstOrDefault(e => e.Id == department.Id);
                if (item != null)
                {
                    item.Name = department.Name;
                    item.DepartmentHeadId = department.DepartmentHeadId;
                    item.Employees = department.Employees;
                }
                else
                    throw new Exception("Department Not Found");
            }
            catch (Exception ex)
            {
                throw new Exception("Error Updating Department."+ ex);
            }
            
        }
        public bool IsEmpty()
        {
            if (Departments.Count == 0)
            {
                return true;
            }
            return false;
        }
        public List<Department> All()
        {
            return Departments.ToList();
        }
        public void Remove(int id)
        {
            try
            {
                var department = Departments.FirstOrDefault(e => e.Id == id);
                if (department != null)
                {
                    Departments.Remove(department);
                }
                else
                    throw new Exception("Department Not Found.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error Removing Department"+ex);
            }
         
        }
        public Department GetDepartment(int id)
        {
            var department = Departments.FirstOrDefault(e => e.Id == id);
            return department;
        }
        public void Fill()
        {
            Departments.Add(
                new Department
                {
                    Id = 1,
                    Name = "D1",
                    DepartmentHeadId = 1,
                    Employees = new List<int>{ 1, 2 }
                }) ;
            Departments.Add(
                new Department
                {
                    Id = 2,
                    Name = "D2",
                    DepartmentHeadId = 1,
                    Employees = new List<int> { 2, 3 }
                });
            Departments.Add(
                new Department
                {
                    Id = 3,
                    Name = "D1",
                    DepartmentHeadId = 1,
                    Employees = new List<int> { 3, 4 }
                });
            Departments.Add(
                new Department
                {
                    Id = 1,
                    Name = "D1",
                    DepartmentHeadId = 1,
                    Employees = new List<int> { 4, 1 }
                });
        }

    }
}
