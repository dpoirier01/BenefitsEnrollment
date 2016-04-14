using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paylocity.API.Models.DTO
{
    public class DependentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }
        public int EmployeeId { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + ' ' + LastName;
            }
        }
    }
}