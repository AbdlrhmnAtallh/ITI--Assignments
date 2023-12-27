using FinalProject_HRsystem.Models.DepartmentINFO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection.Metadata.Ecma335;

namespace FinalProject_HRsystem.Services
{
    public class DepartmentLayer : IDepartmentLayer
    {
        public List<Department> Departments = new List<Department>();

        public int Add(Department department)
        {
            Departments.Add(department);
            return 1;
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
                }
                else
                    throw new Exception("Department Not Found");
            }
            catch (Exception ex)
            {
                throw new Exception("Error Updating Department.", ex);
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
                throw new Exception("Error Removing Department", ex);
            }
         
        }

    }
}
