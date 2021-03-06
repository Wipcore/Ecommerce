﻿using Kooboo.Commerce.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kooboo.Commerce.Web.Areas.Commerce.Models.Activities
{
    public class CreateRuleModel
    {
        public string EventType { get; set; }

        public List<Condition> Conditions { get; set; }

        public CreateRuleModel()
        {
            Conditions = new List<Condition>();
        }
    }
}