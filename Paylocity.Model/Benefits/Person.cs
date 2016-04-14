using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model.Benefits
{
    public abstract class Person
    {
        public abstract string FirstName { get; }
        public abstract string MiddleName { get; }
        public abstract string LastName { get; }
    }
}
