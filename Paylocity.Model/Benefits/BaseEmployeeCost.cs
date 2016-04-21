using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model.Benefits
{
    public class BaseEmployeeCost : BenefitsPriceComponent
    {
        public override decimal Cost()
        {
            return 1000;
        }
    }
}
