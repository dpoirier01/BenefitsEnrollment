using Paylocity.API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paylocity.API.Models.Repository
{
    public interface IBenefitRepository
    {
        
        BenefitDTO GetBenefit();
    }
}