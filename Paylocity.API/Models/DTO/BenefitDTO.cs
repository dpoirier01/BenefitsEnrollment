using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paylocity.API.Models.DTO
{
    public class BenefitDTO
    {
        public int Id { get; set; }
        public decimal? EmployeeCost { get; set; }
        public decimal? DependentCost { get; set; }
    }
}