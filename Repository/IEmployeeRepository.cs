using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IEmployeeRepository
    {
        //Get All Employees  ----SELECT ----RETRIEVE
        // All data should be 
        Task<List<Employee>> GetAllEmployees(); //ASynchronous

        //Add an employee ----INSERT ----CREATE
        Task<int> AddEmployee(Employee employee);

        //update an Employee ----UPDATE ---UPDATE
        Task UpdateEmployee(Employee employee);

        //Find Employee
        Task<ActionResult<Employee>> GetEmployeeId(int id);

        //Delete an Employee
        Task<int> DeleteEmployee(int? id);
    }
}
