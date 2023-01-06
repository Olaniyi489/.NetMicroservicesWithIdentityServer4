using Employer.API.Data;
using Employer.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employer.API.Service
{
    public class EmployerService : IEmployerService
    {
        private readonly EmployerAPIContext _context;

        public EmployerService(EmployerAPIContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employee.ToListAsync();
        }
    }
}
