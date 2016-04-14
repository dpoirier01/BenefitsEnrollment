using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model.Benefits
{
    public abstract class Decorator : Cost
    {
        protected Cost _component;
        protected decimal _amount;

        protected Decorator(Cost component)
        {
            _component = component;
        }
    }
}
