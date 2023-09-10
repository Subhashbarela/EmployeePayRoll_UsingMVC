using BussinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayRollMVC.Controllers
{
    public class AjaxController : Controller
    {
        private readonly IEmployeeBL employeeBL;

        public AjaxController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult EmployeeList()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = employeeBL.GetAllEmployees().ToList();
            return new JsonResult(lstEmployee);
        }
    }
}
