using Paylocity.API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paylocity.API.Models.Repository
{
    public class BenefitRepository : IBenefitRepository, IDisposable 
    {
        internal PaylocityEntities context = new PaylocityEntities();

        public BenefitDTO GetBenefit()
        {
            var benefit = (from ben in context.Benefits
                            select new BenefitDTO()
                            {
                                Id = ben.Id,
                                EmployeeCost = ben.EmployeeCost,
                                DependentCost = ben.DependentCost 
                            }).FirstOrDefault();
            return benefit;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}