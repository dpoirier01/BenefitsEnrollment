using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paylocity.API.Models.DTO
{
    public class EmployeeDTO
    {
        public EmployeeDTO() { }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Salary { get; set; }
        public int? NumberOfPayPeriods { get; set; }
        public List<DependentDTO> lDependents { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + ' ' + LastName;
            }
        }
    }
}