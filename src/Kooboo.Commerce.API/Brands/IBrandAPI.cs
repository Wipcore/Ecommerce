﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.API.Brands
{
    /// <summary>
    /// brand api, only query
    /// </summary>
    public interface IBrandAPI : IBrandQuery
    {
        /// <summary>
        /// create a query
        /// </summary>
        /// <returns>brand query</returns>
        IBrandQuery Query();
    }
}
