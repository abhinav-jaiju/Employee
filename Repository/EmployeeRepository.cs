using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //data fields
        private readonly demoExperionContext _context;

        //Default Constructor
        //Constructor based dependency injection
        public EmployeeRepository(demoExperionContext context)
        {
            _context = context;
        }

        #region Get All Employees
        public async Task<List<Employee>> GetAllEmployees()
        {
            if(_context != null)
            {
               return await _context.Employee.ToListAsync();
            }
            return null;
            //throw new NotImplementedException();
        }
        #endregion

        #region Add Employee
        public async Task<int> AddEmployee(Employee employee)
        {
            if(_context != null)
            {
                await _context.Employee.AddAsync(employee);
                await _context.SaveChangesAsync();
                return employee.EmpId;
            }
            return 0;
        }
        #endregion
        
        #region Update Employee
        public async Task UpdateEmployee(Employee employee)
        {
            if (_context != null)
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.Employee.Update(employee);
                await _context.SaveChangesAsync(); //Commit the transaction
                
            }
        }
        #endregion

        #region Get Employee by Id
        public async Task<ActionResult<Employee>> GetEmployeeId(int id)
        {
            if (_context != null)
            {
                var employee = await _context.Employee.FindAsync(id);// concentrating on primary key
                return employee;
            }
            return null;
        }
        #endregion

        #region Delete an Employee
        public async Task<int> DeleteEmployee(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var employee = await _context.Employee.FirstOrDefaultAsync(emp => emp.EmpId == id);
                
                //check condition
                if(employee != null)
                {
                    _context.Employee.Remove(employee);

                    //commit the trancsaction
                     result = await _context.SaveChangesAsync();
                }

                return result;
            }
            return result;
        }
        #endregion
    }
}
