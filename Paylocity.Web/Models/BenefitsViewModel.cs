using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paylocity.Web.Models
{
    public class BenefitsViewModel
    {
        //[Required(ErrorMessage = "Please select an Employee")]
        //public int SelectedEmployeeId { get; set; }

        //public SelectList Employees { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Please enter an employee name")]
        //public string EmployeeName { get; set; }

        //public string[] Dependents { get; set; }

        public string[] DependentFirstName { get; set; }

        public string[] DependentLastName { get; set; }
    }
}