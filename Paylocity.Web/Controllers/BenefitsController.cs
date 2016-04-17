using Paylocity.Business;
using Paylocity.Model;
using Paylocity.Model.Benefits;
using Paylocity.Model.Benefits.Discounts;
using Paylocity.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paylocity.Web.Controllers
{
    public class BenefitsController : Controller
    {
        BenefitService _service = new BenefitService();

        public ActionResult Index()
        {
            BenefitsViewModel vm = new BenefitsViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostEmployeeDependents(BenefitsViewModel vm)
        {
         
            Model.Dependent dependent;
            Model.Employee employee;
            if (ModelState.IsValid)
            {
                employee = new Model.Employee();
                employee.FirstName = vm.FirstName;
                employee.LastName = vm.LastName;
                int newId = _service.CreateEmployee(employee);

                if ((vm.DependentFirstName.Length > 0 && vm.DependentLastName.Length > 0) && (vm.DependentFirstName[0] != "" && vm.DependentLastName[0] != ""))
                {
                    for (int i = 0; i < vm.DependentFirstName.Count(); i++)
                    {
                        dependent = new Model.Dependent();
                        dependent.EmployeeId = newId;
                        dependent.FirstName = vm.DependentFirstName[i];
                        dependent.LastName = vm.DependentLastName[i];
                        _service.CreateDependent(dependent);
                    }
                }
                return RedirectToAction("GetEmployeeBenefitCost", new { empId = newId });
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult GetEmployeeBenefitCost(int empId)
        {
            BaseEmployeeCost empCost = new BaseEmployeeCost();
            FirstNameBeginsWithLetter_A a_discount = new FirstNameBeginsWithLetter_A(empCost);
            a_discount.Cost();








            // could use auto mapper or something similar
            EmployeeBenefitsCostViewModel vm = new EmployeeBenefitsCostViewModel();
            var r = _service.GetBenefitsEnrollment(empId);
            vm.EmployeeAnnualSalary = r.GetEmployeeAnnualSalary();
            vm.EmployeeBiWeeklySalary = r.EmployeeSalary;
            vm.EmployeeName = r.EmployeeName;
            vm.lDependentsCostInfo = r.GetDependentsSummary();
            vm.EmployeeCostAfterDeductions = r.GetEmployeeCostAfterDeductions();
            vm.EmployeeCostBeforeDeductions = r.EmployeeCost;
            vm.EmployeeDiscountAmount = r.GetEmployeeDiscountAmount();
            vm.TotalDiscountAmount = r.GetEmployeeAndDependentTotalDiscount();
            vm.AnnualTotal = r.GetAnnualEmployeeDependentTotalCost();
            vm.BiWeeklyTotal = r.GetBiWeeklyTotal();
            vm.EmployeeBiWeeklyTotalCost = r.GetEmployeeBiWeeklyTotal();
            vm.EmployeeSalaryAfterDeductions = r.GetAnnualEmployeeSalaryAfterDeductions();
            vm.EmployeeBiWeeklyAfterDeductions = r.GetBiweeklySalaryForEmployeeMinusDeductions();
            return View("GetEmployeeBenefitCost", vm);
        }
    }
}