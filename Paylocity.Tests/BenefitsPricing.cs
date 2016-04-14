using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Model;
using System.Collections.Generic;

namespace Paylocity.Tests
{
    [TestClass]
    public class BenefitsPricing
    {
        [TestMethod]
        public void CalculateAnnualTotal()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.EmployeeName = "Alan Smith";
            bene.EmployeeSalary = 2000;
            bene.EmployeeCost = 1000;
            bene.DependentCost = 500;
            bene.lDependent = new List<Dependent>();
            bene.lDependent.Add(new Dependent() { FirstName = "Adam", LastName = "Smith" });
            bene.lDependent.Add(new Dependent() { FirstName = "James", LastName = "Smith" });
            bene.NumberOfPayPeriods = 26;

            decimal total = bene.GetAnnualTotal();
            Assert.AreEqual(1850, total, "Total + discount not calculated correctly");
        }

        [TestMethod]
        public void CalculateEmployeeAnnualBenefitsCostWithour_A_Discount()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.EmployeeName = "Brad Smith";
            bene.EmployeeCost = 1000;
            bene.NumberOfPayPeriods = 26;

            decimal total = bene.GetEmployeeTotal();

            Assert.AreEqual(1000, total, "Employee cost of benefits without discount not calculated correctly");
        }

        [TestMethod]
        public void CalculateEmployeeAnnualBenefitsCostWith_A_Discount()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.EmployeeName = "Alan Smith";
            bene.EmployeeCost = 1000;
            bene.NumberOfPayPeriods = 26;

            decimal total = bene.GetEmployeeTotal();

            Assert.AreEqual(900, total, "Employee cost of benefits with 'A' discount not calculated correctly");
        }

        [TestMethod]
        public void CalculateBiWeeklyTotal()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.EmployeeName = "Alan Smith";
            bene.EmployeeSalary = 2000;
            bene.EmployeeCost = 1000;
            bene.DependentCost = 500;
            bene.lDependent = new List<Dependent>();
            bene.lDependent.Add(new Dependent() { FirstName = "Adam", LastName = "Smith" });
            bene.lDependent.Add(new Dependent() { FirstName = "James", LastName = "Smith" });
            bene.NumberOfPayPeriods = 26;

            decimal total = bene.GetBiWeeklyTotal();
            Assert.AreEqual(71.15M, Math.Round(total, 2), "Total + discount / pay periods not calculated correctly");
        }

        [TestMethod]
        public void CalculateDependentCost()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.EmployeeName = "Alan Smith";
            bene.EmployeeSalary = 2000;
            bene.EmployeeCost = 1000;
            bene.DependentCost = 500;
            bene.lDependent = new List<Dependent>();
            bene.lDependent.Add(new Dependent() { FirstName = "Adam", LastName = "Smith" });
            bene.lDependent.Add(new Dependent() { FirstName = "James", LastName = "Smith" });
            bene.NumberOfPayPeriods = 26;

            decimal total = bene.GetDependentCost();
            Assert.AreEqual(950, total, "Dependent cost of benefits with 'A' discount not calculated correctly");
        }

        [TestMethod]
        public void CalculateDiscountAmount()
        {
            BenefitsEnrollment bene = new BenefitsEnrollment();
            bene.EmployeeName = "Alan Smith";
            bene.EmployeeSalary = 2000;
            bene.EmployeeCost = 1000;
            bene.DependentCost = 500;
            bene.lDependent = new List<Dependent>();
            bene.lDependent.Add(new Dependent() { FirstName = "Adam", LastName = "Smith" });
            bene.lDependent.Add(new Dependent() { FirstName = "James", LastName = "Smith" });
            bene.NumberOfPayPeriods = 26;

            decimal total = bene.GetDiscountAmount();
            Assert.AreEqual(.2M, total, "Incorrect discount amount");
        }

        [TestMethod]
        public void CalculateEmployeeAnnualSalary()
        {
            Employee emp = new Employee(2000, 26);

            decimal? total = emp.CalculateAnnualSalary();

            Assert.AreEqual(52000M, total, "Incorrect calculation of employee annual salary");
        }
    }
}
