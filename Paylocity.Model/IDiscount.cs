using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model
{
    public interface IDiscount
    {
        bool IsDiscountActive();
        bool EligibleForDiscount();
        decimal DiscountAmount();
        decimal ApplyDiscount();
    }
}
