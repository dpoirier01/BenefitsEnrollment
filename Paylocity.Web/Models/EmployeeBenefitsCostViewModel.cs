using Paylocity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Paylocity.Web.Models
{
    public class EmployeeBenefitsCostViewModel
    {
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("Gross Annual Salary")]
        public decimal EmployeeAnnualSalary { get; set; }

        [DisplayName("Bi-weekly Salary")]
        public decimal EmployeeBiWeeklySalary { get; set; }

        [DisplayName("Dependents")]
        public List<Dependent> lDependentsCostInfo { get; set; }

        [DisplayName("Annual Cost of Benefits before Deductions")]
        public decimal EmployeeCostBeforeDeductions { get; set; }
        
        [DisplayName("Cost of Benefits after Deductions")]
        public decimal EmployeeCostAfterDeductions { get; set; }

        [DisplayName("Dependent Cost")]
        public decimal DependentCost { get; set; }


        [DisplayName("Discount Amount")]
        public decimal EmployeeDiscountAmount { get; set; }

        [DisplayName("Discount Amount")]
        public decimal DependentDiscountAmount { get; set; }

        [DisplayName("Discount Amount")]
        public decimal TotalDiscountAmount { get; set; }

        [DisplayName("Annual Total")]
        public decimal AnnualTotal { get; set; }

        [DisplayName("Bi-weekly Total")]
        public decimal BiWeeklyTotal { get; set; }

        [DisplayName("Salary After Deductions")]
        public decimal EmployeeSalaryAfterDeductions { get; set; }

        [DisplayName("Bi-weekly Income After Deductions")]
        public decimal EmployeeBiWeeklyAfterDeductions { get; set; }

        [DisplayName("Bi-weekly Cost of Benefits")]
        public decimal EmployeeBiWeeklyTotalCost { get; set; }

        [DisplayName("Dependent Bi-weekly Cost of Benefits")]
        public decimal DependentBiWeeklyTotalCost { get; set; }
    }
}