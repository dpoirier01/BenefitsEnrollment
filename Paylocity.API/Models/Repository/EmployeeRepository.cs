using Paylocity.API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paylocity.API.Models.Repository
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private PaylocityEntities context = new PaylocityEntities();

        public IEnumerable<EmployeeDTO> GetEmployees()
        {
            var employees = from emp in context.Employees
                            select new EmployeeDTO()
                            {
                                Id = emp.Id,
                                FirstName = emp.FirstName,
                                LastName = emp.LastName,
                                Salary = emp.Salary,
                            };
            return employees;
        }

        public int CreateEmployee(EmployeeDTO employee)
        {
            var emp = new Employee();
            //emp.Id = employee.Id;
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Salary = 2000;
            emp.NumberOfPayPeriods = 26;
            context.Employees.Add(emp);

            if (context.SaveChanges() > 0)
                return emp.Id;
            else
                return 0;
        }

        public EmployeeDTO GetEmployee(int id)
        {
            var employee = (from emp in context.Employees
                            where emp.Id == id
                            select new EmployeeDTO
                            {
                                Id = emp.Id,
                                FirstName = emp.FirstName,
                                LastName = emp.LastName,
                                Salary = emp.Salary,
                                NumberOfPayPeriods = emp.NumberOfPayPeriods,
                                lDependents = (from deps in context.Dependents
                                               where deps.EmployeeId == emp.Id
                                               select new DependentDTO()
                                               {
                                                   Id = deps.Id,
                                                   FirstName = deps.FirstName,
                                                   LastName = deps.LastName
                                               }).ToList()
                            }).FirstOrDefault();

            return employee;
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