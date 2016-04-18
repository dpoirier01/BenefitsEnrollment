using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model.Benefits.Discounts
{
    public class FirstNameBeginsWithLetter_A : Decorator
    {
        //public decimal Cost { get; set; }

        public FirstNameBeginsWithLetter_A(BenefitsPrice amount) : base(amount)
        {

        }

        public override decimal Cost()
        {
            return base.Cost() * 10;
        }
    }
}
