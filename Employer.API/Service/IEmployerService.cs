using Employer.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employer.API.Service
{
    public interface IEmployerService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
    }
}
