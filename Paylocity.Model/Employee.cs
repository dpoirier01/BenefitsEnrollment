using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model
{
    public class Employee
    {
        //public Employee(decimal? salary, int? numberOfPeriods)
        //{
        //    this.Salary = salary;
        //    this.NumberOfPayPeriods = numberOfPeriods;
        //}

        //public Employee() { }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Salary { get; set; }
        public int? NumberOfPayPeriods { get; set; }
        public List<Dependent> lDependents { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + ' ' + LastName;
            }
        }
    }
}
