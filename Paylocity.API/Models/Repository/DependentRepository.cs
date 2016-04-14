using Paylocity.API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paylocity.API.Models.Repository
{
    public class DependentRepository : IDependentRepository, IDisposable
    {
        private PaylocityEntities context = new PaylocityEntities();

        public IEnumerable<DependentDTO> GetDependentsByEmp(int empId)
        {
            var dependents = from dep in context.Dependents
                             where dep.EmployeeId == empId
                             select new DependentDTO()
                             {
                                 Id = dep.Id,
                                 FirstName = dep.FirstName,
                                 LastName = dep.LastName,
                                 Relationship = dep.Relationship,

                             };
            return dependents;
        }

        public DependentDTO GetDependent(int id)
        {
            var dependent = (from dep in context.Dependents
                             where dep.Id == id
                             select new DependentDTO()
                             {
                                 Id = dep.Id,
                                 FirstName = dep.FirstName,
                                 LastName = dep.LastName,
                                 Relationship = dep.Relationship
                             }).FirstOrDefault();
            return dependent;
        }

        public bool AddDependent(DependentDTO dependent)
        {
            var dep = new Dependent();
            dep.Id = dependent.Id;
            dep.FirstName = dependent.FirstName;
            dep.LastName = dependent.LastName;
            dep.Relationship = dependent.Relationship;
            dep.EmployeeId = dependent.EmployeeId;
            context.Dependents.Add(dep);

            if (context.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}