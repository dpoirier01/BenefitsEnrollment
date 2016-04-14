using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model
{
    public class BenefitsEnrollment
    {
        public string EmployeeName { get; set; }
        public decimal EmployeeSalary { get; set; }
        public decimal EmployeeCost { get; set; }
        public decimal DependentCost { get; set; }
        public int NumberOfPayPeriods { get; set; }
        public List<Dependent> lDependent { get; set; }
        public List<Dependent> lDependentCosts { get; private set; }

        //public BenefitsEnrollment(string employeeName, decimal employeeSalary, decimal employeeCost, decimal dependentCost, int numberOfPeriods, List<Dependent> ldependent)
        //{
        //    this.EmployeeName = employeeName;
        //    this.EmployeeSalary = employeeSalary;
        //    this.EmployeeCost = employeeCost;
        //    this.DependentCost = dependentCost;
        //    this.NumberOfPayPeriods = numberOfPeriods;
        //    this.lDependent = ldependent;
        //}

        // Calculate the cost of benefits for employee
        public decimal GetEmployeeCostAfterDeductions()
        {
            decimal total = 0;
            total = EmployeeCost - this.GetPotentialEmployeeDiscount();
            return total;
        }

        public decimal GetEmployeeAnnualSalary()
        {
            return EmployeeSalary * NumberOfPayPeriods;
        }

        // Get the discount amount for this employee if eligible
        public decimal GetEmployeeDiscountAmount()
        {
            return this.GetPotentialEmployeeDiscountAmount();
        }

        // Calculate the cost of benefits for dependent(s)
        public decimal GetDependentCost(Dependent dependent)
        {
            return DependentCost - this.GetPotentialDependentDiscount(dependent);
        }

        // Get a list of all dependents and their cost of benefits
        public List<Dependent> GetDependentsSummary()
        {
            this.lDependentCosts = new List<Dependent>();
            Dependent dep;
            if (lDependent != null)
            {
                foreach (Dependent d in lDependent)
                {
                    dep = new Dependent();
                    dep.FirstName = d.FirstName;
                    dep.LastName = d.LastName;
                    dep.CostOfBenefits = GetDependentCost(d);
                    dep.BiWeeklyCostOfBenefits = GetDependentBiWeeklyCost(d);
                    dep.Discount = GetPotentialDependentDiscountAmount(d);
                    lDependentCosts.Add(dep);
                }
            }
            return lDependentCosts;
        }

        // Employee annual minus deductions
        public decimal GetAnnualEmployeeSalaryAfterDeductions()
        {
            return (EmployeeSalary * NumberOfPayPeriods) - (GetEmployeeAndDependentTotal());
        }

        // Employee biweekly salary minus deductions
        public decimal GetBiweeklySalaryForEmployeeMinusDeductions()
        {
            decimal total = 0;
            total = EmployeeSalary - GetBiWeeklyTotal();
            return Decimal.Round(total, 2);
        }
       
        // Get the annual cost of benefits for an employee
        public decimal GetAnnualEmployeeDependentTotalCost()
        {
            decimal total = 0;
            total = GetEmployeeAndDependentTotal();
            return total;
        }

        // Calculate the biweekly cost of benefits for a dependent
        public decimal GetDependentBiWeeklyCost(Dependent dependent)
        {
            decimal total = 0;
            if (dependent != null)
                total = (GetDependentCost(dependent) / NumberOfPayPeriods);

            return total;
        }

        // Calculate the biweekly cost of benefits for an employee
        public decimal GetEmployeeBiWeeklyTotal()
        {
            decimal total = 0;
            total = GetEmployeeCostAfterDeductions() / NumberOfPayPeriods;
            return total;
        }

        // Calculate the biweekly total cost for employee and dependent(s)
        public decimal GetBiWeeklyTotal()
        {
            decimal total = 0;

            total = GetEmployeeAndDependentTotal() / NumberOfPayPeriods;
            return total;
        }

        // Calculate the total cost of benefits for employee and dependent(s)
        private decimal GetEmployeeAndDependentTotal()
        {
            decimal total = 0;

            total = GetEmployeeCostAfterDeductions();

            if (lDependent != null)
            {
                foreach (Dependent d in lDependent)
                    total += GetDependentCost(d);
            }
            return total;
        }

        // Calculate the total discount(s) for employee and dependent(s)
        public decimal GetEmployeeAndDependentTotalDiscount()
        {
            decimal dTotalDiscount = 0;
            dTotalDiscount = GetPotentialEmployeeDiscount();
            if (lDependent != null)
            {
                foreach (Dependent d in lDependent)
                {
                    dTotalDiscount += GetPotentialDependentDiscount(d);
                }
            }
            return dTotalDiscount;
        }

        #region Discounts
        private decimal GetPotentialEmployeeDiscount()
        {
            IDiscount employeeLetterADiscount = new FirstNameBeginsWithADiscount(EmployeeName, EmployeeCost);
            return employeeLetterADiscount.ApplyDiscount();
        }

        private decimal GetPotentialDependentDiscount(Dependent dependent)
        {
            IDiscount dependentLetterADiscount = new FirstNameBeginsWithADiscount(dependent.FirstName, DependentCost);
            return dependentLetterADiscount.ApplyDiscount();
        }

        private decimal GetPotentialEmployeeDiscountAmount()
        {
            IDiscount employeeLetterADiscount = new FirstNameBeginsWithADiscount(EmployeeName, EmployeeCost);
            return employeeLetterADiscount.DiscountAmount();

        }
        private decimal GetPotentialDependentDiscountAmount(Dependent dependent)
        {
            IDiscount dependentLetterADiscount = new FirstNameBeginsWithADiscount(dependent.FirstName, DependentCost);
            return dependentLetterADiscount.DiscountAmount();
        }
        #endregion
    }
}
