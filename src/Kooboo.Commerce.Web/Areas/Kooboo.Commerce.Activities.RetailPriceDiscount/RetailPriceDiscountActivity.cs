﻿using Kooboo.CMS.Common.Runtime.Dependency;
using Kooboo.Commerce.Events.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kooboo.Commerce.Activities.RetailPriceDiscount
{
    [Dependency(typeof(IActivity), Key = "RetailPriceDiscount")]
    public class RetailPriceDiscountActivity : ActivityBase<GetPrice>, IHasCustomActivityParameterEditor
    {
        public override string Name
        {
            get
            {
                return "RetailPriceDiscount";
            }
        }

        public override string DisplayName
        {
            get
            {
                return "Apply discount to product retail price";
            }
        }

        protected override void DoExecute(GetPrice @event, ActivityContext context)
        {
            var config = context.ParameterValues.Get<RetailPriceDiscountActivityConfig>("Config");
            if (config == null)
            {
                return;
            }

            var newPrice = config.ApplyDiscount(@event.FinalPrice);
            @event.FinalPrice = newPrice;
        }

        public string GetEditorVirtualPath(ActivityRule rule, AttachedActivityInfo attachedActivityInfo)
        {
            return String.Format("~/Areas/{0}/Views/Config.cshtml", Strings.AreaName);
        }
    }
}