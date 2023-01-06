using EmployerAPI.Controllers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployerAPI.Data
{
    public class EmployeeContextSeed
    {
        public static void SeedAsync(EmployerAPIContext employerAPIContext)
        {
            if (!employerAPIContext.Employee.Any())
            {
                var employee = new List<Employee>
                {
                    new Employee
                    {
                        Id = 1,
                        Name = "Adeola Olatunji",
                        Salary = 4565656,
                        JobTitle = "I.T Personnel",
                        JoinedDate = DateTime.UtcNow,
                        Department = "Head Office"
                    },
                    new Employee
                    {
                        Id = 2,
                        Name = "Chukwu Obi",
                        Salary = 120000,
                        JobTitle = "Operations",
                        JoinedDate = DateTime.UtcNow,
                        Department = "Branch"
                    },
                    new Employee
                    {
                        Id = 3,
                        Name = "Ogochukwu Innocent",
                        Salary = 300000,
                        JobTitle = "Manager",
                        JoinedDate = DateTime.UtcNow,
                        Department = "Sub - Head"
                    },
                     new Employee
                    {
                        Id = 4,
                        Name = "Chukwuma Duru",
                        Salary = 225000,
                        JobTitle = "Services",
                        JoinedDate = DateTime.UtcNow,
                        Department = "Sub-Branch"
                    },
                     new Employee
                    {
                        Id = 5,
                        Name = "Tobi Lawal",
                        Salary = 25000,
                        JobTitle = "Cleaner",
                        JoinedDate = DateTime.UtcNow,
                        Department = "Sub-Head"
                    }
                };

                employerAPIContext.Employee.AddRange(employee);
                employerAPIContext.SaveChanges();
            }
        }
    }
}
