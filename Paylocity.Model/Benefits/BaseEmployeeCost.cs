using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model.Benefits
{
    public class BaseEmployeeCost : Cost
    {
        public override decimal Amount { get { return 1000; } }
    }
}
