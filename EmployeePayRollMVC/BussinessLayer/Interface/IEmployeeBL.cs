﻿using CommonLayer.Model;
using RepositoryLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface IEmployeeBL
    {
        public IEnumerable<Employee> GetAllEmployees();
       public void AddEmployee(Employee employee);
        public void UpdateEmployee(Employee emp);
       public Employee GetEmployeeData(int? empid);
       public void DeleteEmployee(int? empid);
       // public Employee EmployeeLoginDetails(EmployeeLogin login);

    }
}
