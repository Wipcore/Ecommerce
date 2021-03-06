﻿using Kooboo.Commerce.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Activities.Events
{
    public class ActivityDetached : Event
    {
        public ActivityRule Rule { get; private set; }

        public AttachedActivityInfo Activity { get; private set; }

        public ActivityDetached(ActivityRule rule, AttachedActivityInfo activity)
        {
            Rule = rule;
            Activity = activity;
        }
    }
}
