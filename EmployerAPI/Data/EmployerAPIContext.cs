using EmployerAPI.Controllers.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployerAPI.Data
{
    public class EmployerAPIContext : DbContext
    {
        public EmployerAPIContext(DbContextOptions<EmployerAPIContext> options)
           : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
    }
}
