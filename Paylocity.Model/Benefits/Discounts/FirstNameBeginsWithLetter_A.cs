using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model.Benefits.Discounts
{
    public class FirstNameBeginsWithLetter_A : Decorator
    {
       
        public FirstNameBeginsWithLetter_A(BenefitsPriceComponent amount) : base(amount)
        {
        }

        public override decimal Cost()
        {
            
                return base.Cost() * 10;
         
        }
    }
}
