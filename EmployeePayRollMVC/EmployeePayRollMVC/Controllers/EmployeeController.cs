using BussinessLayer.Interface;
using BussinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Service;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayRollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeBL employeeBL;

        public EmployeeController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }
        public IActionResult Index()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = employeeBL.GetAllEmployees().ToList();

            return View(lstEmployee);

        }
        [HttpGet]
        //[Route("Employee/InsertEmpRecords")].... ( Attributs Route)we can change Url address for access 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeBL.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        //Edit the data.........
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeBL.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // Get Details from database
        [HttpGet]
        public IActionResult Details()
        {
            var empId = (int)HttpContext.Session.GetInt32("EmployeeId");
            string empName = HttpContext.Session.GetString("EmployeeName");
            if (empId != 0 && empName != null)
            {
                if (empId == 8 && empName == "Subhash")
                {
                    return RedirectToAction("Index");
                }
                Employee employee = employeeBL.GetEmployeeData(empId);
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        // Delete the Data From Database

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var empId = (int)HttpContext.Session.GetInt32("EmployeeId");
            //var empName = HttpContext.Session.GetString("EmployeeName");
            //if (empId != 0 && empName != null)
            //{
            Employee employee = employeeBL.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        //return RedirectToAction("Delete");


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            employeeBL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        //[Route("Employee/InsertEmpRecords")].... ( Attributs Route)we can change Url address for access 
        public IActionResult Login()
        {
            var loginVar = new EmployeeLogin();
            return View(loginVar);
        }
        [HttpPost]
        public IActionResult Login([Bind] EmployeeLogin login)
        {
            if (ModelState.IsValid)
            {
                var result = employeeBL.EmployeeLoginDetails(login);
                if (result != null)
                {
                    HttpContext.Session.SetInt32("EmployeeId", result.EmployeeId);
                    HttpContext.Session.SetString("EmployeeName", result.EmployeeName);

                    return RedirectToAction("Details");
                }
                return View(login);
            }
            return View(login);
        }
    }
}