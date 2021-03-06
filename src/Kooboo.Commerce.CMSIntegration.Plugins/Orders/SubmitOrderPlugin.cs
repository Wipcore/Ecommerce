﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kooboo.CMS.Sites.Membership;
using Kooboo.Commerce.API.Payments;
using Kooboo.Commerce.API.ShoppingCarts;
using Kooboo.Commerce.CMSIntegration.Plugins.Orders.Models;

namespace Kooboo.Commerce.CMSIntegration.Plugins.Orders
{
    public class SubmitOrderPlugin : SubmissionPluginBase<SubmitOrderModel>
    {
        public SubmitOrderPlugin()
        {
            Parameters.Add("ExpireCart", false);
        }

        protected override SubmissionExecuteResult Execute(SubmitOrderModel model)
        {
            var api = Site.Commerce();

            var member = HttpContext.Membership().GetMembershipUser();
            var cart = api.ShoppingCarts.ByAccountId(member.UUID).FirstOrDefault();
            var orderId = api.Orders.CreateFromCart(cart.Id, new ShoppingContext
            {
                Currency = Site.GetCurrency(),
                Culture = Site.Culture
            });

            if (model.ExpireCart)
            {
                api.ShoppingCarts.ExpireCart(cart.Id);
            }

            return new SubmissionExecuteResult
            {
                Data = new SubmitOrderResult
                {
                    OrderId = orderId
                }
            };
        }
    }
}
