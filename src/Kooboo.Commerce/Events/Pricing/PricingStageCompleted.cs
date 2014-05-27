﻿using Kooboo.Commerce.Orders.Pricing;
using Kooboo.Commerce.Rules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Events.Pricing
{
    [Event(Category = EventCategories.Pricing, Order = 200)]
    public class PricingStageCompleted : DomainEvent
    {
        [JsonIgnore]
        [Reference(Prefix = "")]
        public PricingContext Context { get; private set; }

        [Param]
        public string StageName { get; private set; }

        protected PricingStageCompleted() { }

        public PricingStageCompleted(string stageName, PricingContext context)
        {
            Require.NotNullOrEmpty(stageName, "stageName");
            Require.NotNull(context, "context");

            StageName = stageName;
            Context = context;
        }
    }
}
