﻿using Microsoft.AspNetCore.Mvc;
using Day7.Models;
namespace Day7.Controllers
{
    public class EmployeeController : Controller
    {
        List<Employee> Employees = new List<Employee>();
        
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Save( Employee e)
        {
            if (ModelState.IsValid)
            {
                Employees.Add(new Employee { Id = e.Id, Name = e.Name });
                return View("All",Employees);
            }
            return View("Add");
        }
        public IActionResult All()
        {
            return View(Employees);
        }
    }
}