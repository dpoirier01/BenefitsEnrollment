using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Model;
using System.Collections.Generic;
using Moq;
using Paylocity.API.Models.Repository;
using Paylocity.API.Controllers;
using System.Web.Http.Results;
using Paylocity.API.Models.DTO;
using Paylocity.Model.Benefits;
using Paylocity.Model.Benefits.Discounts;

namespace Paylocity.Tests
{
    [TestClass]
    public class BenefitsPricingTests
    {

        [TestMethod]
        public void CalculateEmployeeDependentCostWith_A_Discounts()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.EmployeeName = "Alan Smith";
            bene.EmployeeSalary = 2000;
            bene.EmployeeCost = 1000;
            bene.DependentCost = 500;
            bene.lDependent = new List<Model.Dependent>();
            bene.lDependent.Add(new Model.Dependent { FirstName = "Adam", LastName = "Smith" });
            bene.lDependent.Add(new Model.Dependent { FirstName = "James", LastName = "Smith" });
            bene.NumberOfPayPeriods = 26;

            decimal total = bene.GetAnnualEmployeeDependentTotalCost();
            Assert.AreEqual(1850, total, "Total + discount not calculated correctly");
        }

        [TestMethod]
        public void CalculateEmployeeAnnualBenefitsCostWithout_A_Discount()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.EmployeeName = "Brad Smith";
            bene.EmployeeCost = 1000;
            bene.NumberOfPayPeriods = 26;

            decimal total = bene.GetEmployeeCostAfterDeductions();

            Assert.AreEqual(1000, total, "Employee cost of benefits without discount not calculated correctly");
        }

        [TestMethod]
        public void CalculateEmployeeAnnualBenefitsCostWith_A_Discount()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.EmployeeName = "Alan Smith";
            bene.EmployeeCost = 1000;
            bene.NumberOfPayPeriods = 26;

            decimal total = bene.GetEmployeeCostAfterDeductions();

            Assert.AreEqual(900, total, "Employee cost of benefits with 'A' discount not calculated correctly");
        }

        [TestMethod]
        public void CalculateBiWeeklyTotal()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.EmployeeName = "Alan Smith";
            //bene.EmployeeSalary = 2000;
            bene.EmployeeCost = 1000;
            bene.DependentCost = 500;
            bene.lDependent = new List<Model.Dependent>();
            bene.lDependent.Add(new Model.Dependent { FirstName = "Adam", LastName = "Smith" });
            bene.lDependent.Add(new Model.Dependent { FirstName = "James", LastName = "Smith" });
            bene.NumberOfPayPeriods = 26;

            decimal total = bene.GetBiWeeklyTotal();
            Assert.AreEqual(71.15M, Math.Round(total, 2), "Total + discount / pay periods not calculated correctly");
        }

        [TestMethod]
        public void CalculateDependentCostWith_A_Discount()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.DependentCost = 500;

            Model.Dependent dep = new Model.Dependent();
            dep.FirstName = "Adam";
            dep.LastName = "Smith";


            decimal total = bene.GetDependentCost(dep);
            Assert.AreEqual(450, total, "Dependent cost of benefits with 'A' discount not calculated correctly");
        }

        [TestMethod]
        public void CalculateDependentCostWithout_A_Discount()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.DependentCost = 500;

            Model.Dependent dep = new Model.Dependent();
            dep.FirstName = "Greg";
            dep.LastName = "Smith";


            decimal total = bene.GetDependentCost(dep);
            Assert.AreEqual(500, total, "Dependent cost of benefits with 'A' discount not calculated correctly");
        }

        [TestMethod]
        public void CalculateDiscountAmount()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.EmployeeName = "Alan Smith";
            //bene.EmployeeSalary = 2000;
            bene.EmployeeCost = 1000;
            bene.DependentCost = 500;
            bene.lDependent = new List<Model.Dependent>();
            bene.lDependent.Add(new Model.Dependent { FirstName = "Adam", LastName = "Smith" });
            bene.lDependent.Add(new Model.Dependent { FirstName = "James", LastName = "Smith" });
            bene.NumberOfPayPeriods = 26;

            decimal total = bene.GetEmployeeAndDependentTotalDiscount();
            Assert.AreEqual(150, total, "Incorrect discount amount");
        }

        [TestMethod]
        public void CalculateEmployeeAnnualSalary_Minus_Deductions_With_EmployeeDependent_Discounts()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.EmployeeName = "Alan Smith";
            bene.EmployeeSalary = 2000;
            bene.NumberOfPayPeriods = 26;
            bene.EmployeeCost = 1000;
            bene.DependentCost = 500;
            bene.lDependent = new List<Model.Dependent>();
            bene.lDependent.Add(new Model.Dependent { FirstName = "Adam", LastName = "Smith" });
            bene.lDependent.Add(new Model.Dependent { FirstName = "James", LastName = "Smith" });

            decimal total = bene.GetAnnualEmployeeSalaryAfterDeductions();

            Assert.AreEqual(50150M, total, "Incorrect calculation of employee annual salary");
        }

        [TestMethod]
        public void CalculateEmployeeAnnualSalary_Minus_Deductions_WithOut_EmployeeDependent_Discounts()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.EmployeeName = "Greg Smith";
            bene.EmployeeSalary = 2000;
            bene.NumberOfPayPeriods = 26;
            bene.EmployeeCost = 1000;
            bene.DependentCost = 500;
            bene.lDependent = new List<Model.Dependent>();
            bene.lDependent.Add(new Model.Dependent { FirstName = "Bob", LastName = "Smith" });
            bene.lDependent.Add(new Model.Dependent { FirstName = "James", LastName = "Smith" });

            decimal total = bene.GetAnnualEmployeeSalaryAfterDeductions();

            Assert.AreEqual(50000M, total, "Incorrect calculation of employee annual salary");
        }

        [TestMethod]
        public void CalculateEmployeeBiWeeklySalary_Minus_Deductions_WithOut_EmployeeDependent_Discounts()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.EmployeeName = "Greg Smith";
            bene.EmployeeSalary = 2000;
            bene.NumberOfPayPeriods = 26;
            bene.EmployeeCost = 1000;
            bene.DependentCost = 500;
            bene.lDependent = new List<Model.Dependent>();
            bene.lDependent.Add(new Model.Dependent { FirstName = "Bob", LastName = "Smith" });
            bene.lDependent.Add(new Model.Dependent { FirstName = "James", LastName = "Smith" });

            decimal total = bene.GetBiweeklySalaryForEmployeeMinusDeductions();

            Assert.AreEqual(1923.08M, total, "Incorrect calculation of employee annual salary");
        }

        [TestMethod]
        public void CalculateEmployeeBiWeeklySalary_Minus_Deductions_With_EmployeeDependent_Discounts()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.EmployeeName = "Alan Smith";
            bene.EmployeeSalary = 2000;
            bene.NumberOfPayPeriods = 26;
            bene.EmployeeCost = 1000;
            bene.DependentCost = 500;
            bene.lDependent = new List<Model.Dependent>();
            bene.lDependent.Add(new Model.Dependent { FirstName = "Adam", LastName = "Smith" });
            bene.lDependent.Add(new Model.Dependent { FirstName = "James", LastName = "Smith" });

            decimal total = bene.GetBiweeklySalaryForEmployeeMinusDeductions();

            Assert.AreEqual(1928.85M, total, "Incorrect calculation of employee annual salary");
        }

        [TestMethod]
        public void Calculate_Letter_A_Discount_Amount()
        {
            FirstNameBeginsWithADiscount discount = new FirstNameBeginsWithADiscount("Alex", 1000);

            decimal? total = discount.ApplyDiscount();

            Assert.AreEqual(100, total, "Incorrect calculation of employee annual salary");
        }

        [TestMethod]
        public void Calculate_NoLetter_A_Discount()
        {
            FirstNameBeginsWithADiscount discount = new FirstNameBeginsWithADiscount("Bob", 1000);

            decimal? total = discount.ApplyDiscount();

            Assert.AreEqual(0, total, "Incorrect calculation of employee annual salary");
        }

        [TestMethod]
        public void BenefitsAPI_GetEmployee_ReturnsEmployee()
        {
            var employeeMock = new Mock<IEmployeeRepository>();

            EmployeeDTO emp = new EmployeeDTO()
            {
                Id = 4,
                FirstName = "Greg",
                LastName = "Reynolds",
                NumberOfPayPeriods = 26
            };

            employeeMock.Setup(service => service.GetEmployee(4)).Returns(emp);

            var beneController = new BenefitsController(employeeMock.Object);

            var value = beneController.GetEmployee(4) as OkNegotiatedContentResult<EmployeeDTO>;

            Assert.IsTrue(value.Content.Id == 4);
            Assert.IsTrue(value.Content.FirstName == "Greg");
            Assert.IsTrue(value.Content.LastName == "Reynolds");
            Assert.IsTrue(value.Content.NumberOfPayPeriods == 26);
        }

        [TestMethod]
        public void BenefitsAPI_Silly_Test()
        {
            // arrange
            var employeeRepo = new Mock<IEmployeeRepository>();
            var dependentRepo = new Mock<IDependentRepository>();
            var benefitsRepo = new Mock<IBenefitRepository>();

            employeeRepo.Setup(e => e.GetEmployees()).Returns(new List<EmployeeDTO>());
            dependentRepo.Setup(d => d.GetDependentsByEmp(4)).Returns(new List<DependentDTO>());
            benefitsRepo.Setup(b => b.GetBenefit()).Returns(new BenefitDTO());

            // act
            var beneController = new BenefitsController(employeeRepo.Object, benefitsRepo.Object, dependentRepo.Object);

            var empValue = beneController.GetEmployees() as OkNegotiatedContentResult<List<EmployeeDTO>>;

            // assert
            employeeRepo.Verify(e => e.GetEmployees(), Times.Exactly(1));
            dependentRepo.Verify(d => d.GetDependentsByEmp(4), Times.Never());
            benefitsRepo.Verify(b => b.GetBenefit(), Times.Never());
        }

        [TestMethod]
        public void the_employee_repository_returns_employee_id_after_create_method()
        {
            EmployeeDTO emp = new EmployeeDTO()
            {
                FirstName = "John",
                LastName = "Johnson",
                Salary = 2000,
                NumberOfPayPeriods = 26
            };

            var employeeRepo = new Mock<IEmployeeRepository>();

            var beneAPI = new BenefitsController(employeeRepo.Object);

            var newEmpId = beneAPI.CreateEmployee(emp) as OkNegotiatedContentResult<int>;

            Assert.IsTrue(newEmpId.Content.GetType() == typeof(int));
        }

        [TestMethod]
        public void BenefitsEnrollmentAPI_Enroll_ReturnsNotFoundError()
        {
            // arrange
            var employeeRepo = new Mock<IEmployeeRepository>();
            var dependentRepo = new Mock<IDependentRepository>();
            var benefitsRepo = new Mock<IBenefitRepository>();

            //benefitsRepo.Setup(b => b).Returns(new BenefitDTO());
        }

        [TestMethod]
        public void Benefits_Employee_Cost_Returns_Correct_Cost()
        {
            BaseEmployeeCost empCost = new BaseEmployeeCost();

            Assert.AreEqual(empCost.Cost(), 1000M);
        }

        [TestMethod]
        public void Benefits_Dependent_Cost_Returns_Correct_Cost()
        {
            BaseDependentCost depCost = new BaseDependentCost();

            Assert.AreEqual(depCost.Cost(), 500M);
        }

        //[TestMethod]
        //[ExpectedException(typeof(DivideByZeroException))]
        //public void letter_A_dicount_cost_calculation_raises_exception_divide_by_zero()
        //{
        //    BaseDependentCost baseCost = new BaseDependentCost();

        //    var discount = new FirstNameBeginsWithLetter_A(baseCost, 0);

        //    discount.Cost();
        //}
    }
}
