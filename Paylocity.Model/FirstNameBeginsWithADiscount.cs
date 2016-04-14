using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model
{
    public class FirstNameBeginsWithADiscount : IDiscount 
    {
        private readonly decimal LetterADiscount = 10;
        private readonly string LetterAString = "a";
        private readonly bool IsActive = true;
        private string Name { get; set; }
        private decimal AmountToApply { get; set; }

        public FirstNameBeginsWithADiscount(string name, decimal amountToApply)
        {
            this.Name = name;
            this.AmountToApply = amountToApply;
        }

        public bool IsDiscountActive()
        {
            return IsActive;
        }

        public bool EligibleForDiscount()
        {
            if (this.Name.Trim().ToLower().StartsWith(LetterAString))
                return true;
            else
                return false;
        }

        public decimal DiscountAmount()
        {
            if (IsActive)
                if (EligibleForDiscount())
                    return LetterADiscount;
                else
                    return 0;
            else
                return 0;
        }

        public decimal ApplyDiscount()
        {
            if (IsActive)
                if (EligibleForDiscount())
                    return this.AmountToApply * (LetterADiscount / 100);
                else
                    return 0;
            else
                return 0;
        }
    }
}
