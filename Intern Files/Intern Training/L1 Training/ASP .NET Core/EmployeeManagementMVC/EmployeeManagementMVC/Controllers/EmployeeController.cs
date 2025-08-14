using EmployeeManagementMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<EmployeeModel> employees= new List<EmployeeModel>
        {
            new EmployeeModel{Id=100,Name="Balaji",Department="CSE",email="balajistunner08@gmail.com"},
            new EmployeeModel{Id=101,Name="Mukesh",Department="AIDS",email="Muku@gmail.com"},

        };
        // GET: Employee
        public ActionResult Index()
        {
            return View(employees);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            employee.Id = employees.Max(x => x.Id);
            employees.Add(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        { 
            var emp= employees.FirstOrDefault(e=>e.Id.Equals(id));
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel employee)
        {
            var emp = employees.FirstOrDefault(e => e.Id.Equals(employee.Id));
            if (emp != null)
            {
                emp.Name=employee.Name;
                emp.Department=employee.Department;
                emp.email = employee.email;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id) 
        {
            var emp = employees.FirstOrDefault(e => e.Id.Equals(id));
            return View(emp);
        }
        [HttpPost]
        public ActionResult Delete(EmployeeModel employee)
        {
            var emp = employees.FirstOrDefault(e => e.Id.Equals(employee.Id));
            if (emp != null)
            {
                employees.Remove(emp);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)

        {

            var emp = employees.FirstOrDefault(e => e.Id.Equals(id));

            return View(emp);

        }

    }
}