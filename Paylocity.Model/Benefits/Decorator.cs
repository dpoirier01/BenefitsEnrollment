using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model.Benefits
{
    public abstract class Decorator : BenefitsPrice
    {
        BenefitsPrice _basePrice = null;

        protected Decorator(BenefitsPrice cost)
        {
            _basePrice = cost;
        }

        public override decimal Cost()
        {
            return _basePrice.Cost();
        }
    }
}
