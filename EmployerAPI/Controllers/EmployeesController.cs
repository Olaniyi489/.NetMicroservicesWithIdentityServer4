using EmployerAPI.Controllers.Model;
using EmployerAPI.Interface;
using EmployerAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployerAPI.Model;

namespace EmployerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    [Authorize("ClientPolicy")] 
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployerAPI.Model.Employee>>> Get()
        {
            var employees = await _employeeService.GetAllAsync();

            return base.Ok(employees.Select(e => new EmployerAPI.Model.Employee
            {
                Name = e.Name,
                Salary = e.Salary,
                JobTitle = e.JobTitle,
                JoinedDate = e.JoinedDate,
                Department = e.Department
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Model.Employee>> Get(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<EmployerAPI.Model.Employee>> Post(EmployerAPI.Model.Employee employeeDto)
        {
            var employee = new Model.Employee
            {
                Name = employeeDto.Name,
                Salary = employeeDto.Salary,
                JobTitle = employeeDto.JobTitle,
                JoinedDate = employeeDto.JoinedDate,
                Department = employeeDto.Department
            };

            var createdEmployee = await _employeeService.CreateAsync(employee);

            return CreatedAtAction(nameof(Get), new { id = createdEmployee.Name }, employeeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Model.Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            try
            {
                await _employeeService.UpdateAsync(employee);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
