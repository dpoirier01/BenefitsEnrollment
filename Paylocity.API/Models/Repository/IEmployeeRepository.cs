using Paylocity.API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.API.Models.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployee(int id);
        int CreateEmployee(EmployeeDTO employee);
    }
}
