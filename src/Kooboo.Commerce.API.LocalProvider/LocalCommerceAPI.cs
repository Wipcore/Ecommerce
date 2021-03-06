﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Kooboo.Commerce.Data;
using Kooboo.CMS.Common.Runtime.Dependency;
using Kooboo.CMS.Common.Runtime;
using Kooboo.Commerce.API.HAL;

namespace Kooboo.Commerce.API.LocalProvider
{
    /// <summary>
    /// local commerce api
    /// this api uses the Kooboo.Commerce dll directly.
    /// </summary>
    [Dependency(typeof(ICommerceAPI), ComponentLifeStyle.InRequestScope)]
    public class LocalCommerceAPI : CommerceAPIBase
    {
        protected HalContext HalContext = null;

        /// <summary>
        /// set the commerce instance and language to HttpContext.Current.Items.
        /// so that the ICommerceInstanceManager can OpenInstance by using HttpContextItemCommerceInstanceNameResolver
        /// </summary>
        /// <param name="instance">commerce instance name</param>
        /// <param name="language">language</param>
        /// <param name="currency">currency</param>
        /// <param name="settings">kooboo cms site's custom field settings</param>
        public override void InitCommerceInstance(string instance, string language, string currency, Dictionary<string, string> settings)
        {
            HalContext = new HalContext();
            HalContext.WebContext = HttpContext.Current;
            HalContext.CommerceInstance = instance;
            HalContext.Language = language;
            HalContext.Currency = currency;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items[HttpCommerceInstanceNameResolverBase.DefaultParamName] = instance;
                HttpContext.Current.Items["language"] = language;
            }
        }

        protected override Q GetAPI<Q>()
        {
            var q = base.GetAPI<Q>();
            if (q is IHalContextAware)
            {
                ((IHalContextAware)q).HalContext = HalContext;
            }
            return q;
        }
    }
}
