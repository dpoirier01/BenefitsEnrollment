using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paylocity.API.Models.DTO
{
    public class BenefitsEnrollmentDTO
    {
        public string EmployeeName { get; set; }
        public decimal? EmployeeSalary { get; set; }
        public decimal? EmployeeCost { get; set; }
        public decimal? DependentCost { get; set; }
        public int? NumberOfPayPeriods { get; set; }
        public IEnumerable<DependentDTO> lDependent { get; set; }
    }
}