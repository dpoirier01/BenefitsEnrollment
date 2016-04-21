using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model.Benefits
{
    public class BaseDependentCost : BenefitsPriceComponent
    {
        public override decimal Cost()
        {
            return 500;
        }  
    }
}
