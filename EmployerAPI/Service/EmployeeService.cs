using EmployerAPI.Controllers.Model;
using EmployerAPI.Data;
using EmployerAPI.Interface;
using EmployerAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee = EmployerAPI.Model.Employee;

namespace EmployerAPI.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployerAPIContext _context;

        public EmployeeService(EmployerAPIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Model.Employee>> GetAllAsync()
        {
            var employees = await _context.Employee.ToListAsync();
            return employees.Select(e => new Employee
            {
                Name = e.Name,
                Salary = e.Salary,
                JobTitle = e.JobTitle,
                JoinedDate = e.JoinedDate,
                Department = e.Department
            });
        }

        public async Task<Controllers.Model.Employee> GetByIdAsync(int id)
        {
            return await _context.Employee.FindAsync(id);
        }

        public async Task<Model.Employee> CreateAsync(Controllers.Model.Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();
            return new Model.Employee
            {
                Name = employee.Name,
                Salary = employee.Salary,
                JobTitle = employee.JobTitle,
                JoinedDate = employee.JoinedDate,
                Department = employee.Department
            };
        }

        public async Task<Controllers.Model.Employee> UpdateAsync(Controllers.Model.Employee employee)
        {
            _context.Employee.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
