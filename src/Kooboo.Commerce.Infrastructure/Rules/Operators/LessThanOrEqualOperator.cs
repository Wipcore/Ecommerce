﻿using Kooboo.CMS.Common.Runtime.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Rules.Operators
{
    public class LessThanOrEqualOperator : IComparisonOperator
    {
        public string Name
        {
            get
            {
                return "less than or equal";
            }
        }

        public string Alias
        {
            get
            {
                return "<=";
            }
        }

        public bool Apply(ConditionParameter param, object paramValue, object inputValue)
        {
            return !ComparisonOperators.GreaterThan.Apply(param, paramValue, inputValue);
        }
    }
}
