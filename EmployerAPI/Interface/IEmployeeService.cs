using EmployerAPI.Controllers.Model;
using EmployerAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployerAPI.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Model.Employee>> GetAllAsync(); 
        Task<Controllers.Model.Employee> GetByIdAsync(int id);
        Task<Model.Employee> CreateAsync(Controllers.Model.Employee employee);
        Task<Controllers.Model.Employee> UpdateAsync(Controllers.Model.Employee employee);
        Task DeleteAsync(int id);
    }
}
