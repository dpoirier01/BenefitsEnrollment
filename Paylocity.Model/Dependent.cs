using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model
{
    public class Dependent
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal CostOfBenefits { get; set; }
        public decimal Discount { get; set; }
        public decimal? AnnualCostOfBenefits { get; set; }
        public decimal? BiWeeklyCostOfBenefits { get; set; }
    }
}
