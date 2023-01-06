using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeMvcClient.Models;

namespace EmployeeMvcClient.Data
{
    public class EmployeeMvcClientContext : DbContext
    {
        public EmployeeMvcClientContext (DbContextOptions<EmployeeMvcClientContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeMvcClient.Models.EmployeeMvc> EmployeeMvc { get; set; } = default!;
    }
}
