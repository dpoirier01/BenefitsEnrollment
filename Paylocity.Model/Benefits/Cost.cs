﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paylocity.Model.Benefits
{
    public abstract class Cost
    {
        public abstract decimal Amount { get; }
    }
}