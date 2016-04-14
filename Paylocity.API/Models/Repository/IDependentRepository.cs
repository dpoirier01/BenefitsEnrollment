using Paylocity.API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.API.Models.Repository
{
    public interface IDependentRepository
    {
        IEnumerable<DependentDTO> GetDependentsByEmp(int EmpId);
        DependentDTO GetDependent(int id);
        bool AddDependent(DependentDTO dependent);
    }
}
