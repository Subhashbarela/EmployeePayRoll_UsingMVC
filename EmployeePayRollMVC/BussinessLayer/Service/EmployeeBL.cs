using BussinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class EmployeeBL : IEmployeeBL
    {
        IEmployeeRL iRepo;
        public EmployeeBL(IEmployeeRL iRepo)
        {
            this.iRepo = iRepo;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return this.iRepo.GetAllEmployees();
        }
        public void AddEmployee(Employee employee)
        {
             this.iRepo.AddEmployee(employee);

        }
        public void UpdateEmployee(Employee emp)
        {
            this.iRepo.UpdateEmployee(emp);

        }
        public void DeleteEmployee(int? empid)
        {
             this.iRepo.DeleteEmployee(empid);
        }
       
        public Employee GetEmployeeData(int? empid)
        {
            return this.iRepo.GetEmployeeData(empid);
        }
        //public Employee EmployeeLoginDetails(EmployeeLogin login)
        //{
        //    return this.iRepo.EmployeeLoginDetails(login);
        //}

    }
}
