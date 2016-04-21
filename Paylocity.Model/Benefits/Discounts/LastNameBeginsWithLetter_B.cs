using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model.Benefits.Discounts
{
    public class LastNameBeginsWithLetter_B :Decorator 
    {
        public LastNameBeginsWithLetter_B(BenefitsPriceComponent amount) : base(amount)
        {

        }

        public override decimal Cost()
        {
            return base.Cost() * 3;
        }
    }
}
