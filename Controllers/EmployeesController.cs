using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //data fields
        private readonly IEmployeeRepository _empRepository;

        //constructor injection
        public EmployeesController(IEmployeeRepository empRepository)
        {
            _empRepository = empRepository;
        }

        #region Get All Employees
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesAll()
            {
                return await _empRepository.GetAllEmployees();
            }
        #endregion

        #region Add an Employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                  var employeeId =  await _empRepository.AddEmployee(employee);
                    if (employeeId > 0)
                    {
                        return Ok(employeeId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        #region Update an Employee
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _empRepository.UpdateEmployee(employee);
                        return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Find An Employee
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeId(int id)
        {
            try
            {
                var employee = await _empRepository.GetEmployeeId(id);
                if(employee == null)
                {
                    return NotFound();
                }
                return employee;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion

        #region Delete An Employee : 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _empRepository.DeleteEmployee(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}

