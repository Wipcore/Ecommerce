﻿using Kooboo.CMS.Common.Runtime.Dependency;
using Kooboo.Commerce.API.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kooboo.Commerce.CMSIntegration.DataSources.Sources
{
    [Dependency(typeof(ICommerceSource), Key = "Countries")]
    public class CountrySource : ApiCommerceSource
    {
        public CountrySource()
            : base("Countries", typeof(ICountryQuery))
        {
        }
    }
}