using MvcProjectDemo_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;


namespace MvcProjectDemo_.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        public ActionResult Index()
        {
            List<Employee> data = GetAllEmployee();

            return View(data);
        }
        private List<Employee> GetAllEmployee()
        {
            return  new List<Employee>()
            {
                new Employee { Id = 1,Name = "Kiran",Salary = 1000000 },
                new Employee { Id = 2,Name = "Abhi",Salary = 10 },
                new Employee { Id = 3,Name = "kislay",Salary = 150000 },
                new Employee { Id = 4,Name = "Dipali",Salary = 34000 },
                new Employee { Id = 5,Name = "Neha",Salary = 29900 },
                new Employee { Id = 6,Name = "Yash",Salary = 284000 },
                new Employee { Id = 7,Name = "Akshay",Salary = 465000 },
                new Employee { Id = 8,Name = "Rohit",Salary = 147000 },

            };


        }
        public ViewResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult AllEmployee()
        {
            List<Employee> emp = new List<Employee>() { 
                new Employee() { Id = 1,Name = "sani", Salary = 1000 },
                new Employee() { Id = 2,Name = "sani", Salary = 1000 },
                new Employee() { Id = 3,Name = "sani", Salary = 1000 },

            };



            return View(emp);
        }
    }
}