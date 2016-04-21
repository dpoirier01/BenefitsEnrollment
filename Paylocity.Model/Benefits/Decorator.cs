using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model.Benefits
{
    public abstract class Decorator : BenefitsPriceComponent
    {
        BenefitsPriceComponent _basePrice = null;

        protected Decorator(BenefitsPriceComponent cost)
        {
            _basePrice = cost;
        }

        public override decimal Cost()
        {
            return _basePrice.Cost();
        }
    }
}
