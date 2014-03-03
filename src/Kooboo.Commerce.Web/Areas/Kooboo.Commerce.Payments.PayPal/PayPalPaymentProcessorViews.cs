﻿using Kooboo.CMS.Common.Runtime.Dependency;
using Kooboo.Commerce.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kooboo.Commerce.Payments.PayPal
{
    [Dependency(typeof(IPaymentProcessorViews), Key = "Kooboo.Commerce.Payments.PayPal.PayPalPaymentProcessorViews")]
    public class PayPalPaymentProcessorViews : IPaymentProcessorViews
    {
        public string PaymentProcessorName
        {
            get
            {
                return Strings.PaymentProcessorName;
            }
        }

        public System.Web.Mvc.RedirectToRouteResult Settings(System.Web.Mvc.ControllerContext context)
        {
            return Routes.RedirectToAction("Settings", "Home", new { area = Strings.AreaName });
        }
    }
}