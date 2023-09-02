using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class EmployeeRepository : IEmployeeRL
    {
        private readonly IConfiguration Configuration;
        public EmployeeRepository(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }      
  
        // Get All Employee Data from Daatabase
        public IEnumerable<Employee> GetAllEmployees()
        {
            List<Employee> lstemployee = new List<Employee>();

            SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll"));            
                con.Open();
                
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Employee employee = new Employee();
                        //  Console.WriteLine("Emp_Name : " + dr.GetValue(0).ToString());
                        employee.EmployeeId = Convert.ToInt32(dr["EmployeeID"]);
                        employee.EmployeeName = dr["EmployeeName"].ToString();
                        employee.ProfileImage = dr["ProfileImage"].ToString();
                        employee.Department = dr["Department"].ToString();
                        employee.Gender = dr["Gender"].ToString();
                        employee.Salary = Convert.ToInt64(dr["Salary"]);
                        employee.StartDate = Convert.ToDateTime(dr["StartDate"]);
                        employee.Notes = dr["Notes"].ToString();

                        lstemployee.Add(employee);
                    }              
                
                   con.Close();                
            
            return lstemployee;
        }
        //To Add new employee record    
        public Employee AddEmployee(Employee employee)
        {
            SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")) ;
            
                
                try
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                    con.Open();
                    cmd.ExecuteNonQuery();                   
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return employee;

            
        }
        //To Update the records of a particluar employee    
        public void UpdateEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll"));
            try
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                cmd.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@ProfileImage", emp.ProfileImage);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@StartDate", emp.StartDate);
                cmd.Parameters.AddWithValue("@Notes", emp.Notes);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
                     

        }
        //Get the details of a particular employee    
        public Employee GetEmployeeData(int? empid)
        {
            Employee employee = new Employee();
            SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll"));
            try
            {

                con.Open();
              
                string sqlQuery = "SELECT * FROM Employee WHERE EmployeeID= " + empid;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                SqlDataReader dr = cmd.ExecuteReader();
                Employee emp = new Employee();

                while (dr.Read())
                {
                    employee.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                    employee.EmployeeName = dr["EmployeeName"].ToString();
                    employee.ProfileImage = dr["ProfileImage"].ToString();
                    employee.Department = dr["Department"].ToString();
                    employee.Gender = dr["Gender"].ToString();
                    employee.Salary = Convert.ToInt64(dr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(dr["StartDate"]);
                    employee.Notes = dr["Notes"].ToString();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            
            return employee;
        }
        //To Delete the record on a particular employee    
        public void DeleteEmployee(int? empid)
        {
            SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll"));
            
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeId", empid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();           
            
        }      
       

    }
}

