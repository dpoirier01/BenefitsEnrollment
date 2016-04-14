using Paylocity.API.Models;
using Paylocity.API.Models.DTO;
using Paylocity.API.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;

namespace Paylocity.API.Controllers
{
    public class BenefitsController : ApiController
    {
        private IEmployeeRepository _employeeRepo;
        private IBenefitRepository _benefitRepo;
        private IDependentRepository _dependentRepo;

        public BenefitsController(IEmployeeRepository employeeRepo)
        {
            this._employeeRepo = employeeRepo;
        }

        public BenefitsController(IDependentRepository dependentRepo)
        {
            this._dependentRepo = dependentRepo;
        }

        public BenefitsController(IEmployeeRepository employeeRepo, IBenefitRepository benefitRepo, IDependentRepository dependentRepo)
        {
            this._employeeRepo = employeeRepo;
            this._benefitRepo = benefitRepo;
            this._dependentRepo = dependentRepo;
        }

        [HttpGet]
        [Route("api/Benefits/GetEmployee")]
        [ResponseType(typeof(EmployeeDTO))]
        public IHttpActionResult GetEmployee(int id)
        {
            EmployeeDTO employee = _employeeRepo.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet]
        [Route("api/Benefits/GetEmployees")]
        [ResponseType(typeof(EmployeeDTO))]
        public IHttpActionResult GetEmployees()
        {
            IEnumerable<EmployeeDTO> employees = _employeeRepo.GetEmployees().ToList();

            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpPost]
        [Route("api/Benefits/CreateDependent")]
        [ResponseType(typeof(HttpResponseMessage))]
        public IHttpActionResult CreateDependent([FromBody] DependentDTO dependent)
        {
            try
            {
                if (_dependentRepo.AddDependent(dependent))
                    return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
            return InternalServerError();
        }

        [HttpPost]
        [Route("api/Benefits/CreateEmployee")]
        [ResponseType(typeof(HttpResponseMessage))]
        public IHttpActionResult CreateEmployee([FromBody] EmployeeDTO employee)
        {
            int newId = 0;
            try
            {
                newId = _employeeRepo.CreateEmployee(employee);
                return Ok(newId);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/Benefits/BenefitsEnrollment/{empId}")]
        [ResponseType(typeof(BenefitsEnrollmentDTO))]
        public IHttpActionResult BenefitsEnrollment(int empId)
        {
            BenefitDTO benefit = _benefitRepo.GetBenefit();
            EmployeeDTO employee = _employeeRepo.GetEmployee(empId);
            BenefitsEnrollmentDTO beneEnrollment = new BenefitsEnrollmentDTO();

            beneEnrollment.DependentCost = benefit.DependentCost;
            beneEnrollment.EmployeeCost = benefit.EmployeeCost;
            beneEnrollment.EmployeeName = employee.FullName;
            beneEnrollment.EmployeeSalary = employee.Salary;
            beneEnrollment.NumberOfPayPeriods = employee.NumberOfPayPeriods;
            if (employee.lDependents.Count() > 0)
            {
                beneEnrollment.lDependent = new List<DependentDTO>();
                beneEnrollment.lDependent = employee.lDependents;
            }

            if (beneEnrollment == null)
            {
                return NotFound();
            }
            return Ok(beneEnrollment);
        }

    }
}
