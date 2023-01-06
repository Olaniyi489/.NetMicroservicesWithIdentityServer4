using Employee.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Client.ApiService
{
    public interface IEmployeeApiService
    {
        Task<IEnumerable<EmployeeClientModel>> GetEmployees();
        Task<EmployeeClientModel> GetEmployee(int id);
        Task<EmployeeClientModel> CreateEmployee(EmployeeClientModel employeeClientModel);
        Task<EmployeeClientModel> UpdateEmployee(EmployeeClientModel employeeClientModel);
        Task DeleteEmployee(int id);
        Task<UserInfoViewModel> GetUserInfo();
    }
}
