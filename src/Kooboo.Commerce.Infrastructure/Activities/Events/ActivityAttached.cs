﻿using Kooboo.Commerce.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Activities.Events
{
    public class ActivityAttached : Event
    {
        public ActivityRule Rule { get; private set; }

        public AttachedActivityInfo AttachedActivityInfo { get; private set; }

        public ActivityAttached(ActivityRule rule, AttachedActivityInfo attachedActivityInfo)
        {
            Rule = rule;
            AttachedActivityInfo = attachedActivityInfo;
        }
    }
}
