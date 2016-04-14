using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model.Benefits
{
    public class Dependent : Person
    {
        public Dependent(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public override string FirstName { get; }
        public override string MiddleName { get; }
        public override string LastName { get; }
    }
}
