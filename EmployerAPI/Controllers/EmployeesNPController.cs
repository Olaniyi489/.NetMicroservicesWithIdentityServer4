using EmployerAPI.Interface;
using EmployerAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesNPController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesNPController(IEmployeeService employeeService)
        {
           
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            var employees = await _employeeService.GetAllAsync();

            return Ok(employees.Select(e => new Employee
            {
                Name = e.Name,
                Salary = e.Salary,
                JobTitle = e.JobTitle,
                JoinedDate = e.JoinedDate,
                Department = e.Department
            }));
        }
    }
}
