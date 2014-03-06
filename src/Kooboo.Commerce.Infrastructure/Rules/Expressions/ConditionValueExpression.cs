﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Rules.Expressions
{
    public class ConditionValueExpression : Expression
    {
        public string DataSourceId { get; private set; }

        public string Value { get; private set; }

        public ConditionValueExpression(string value, string dataSourceId)
        {
            Value = value;
            DataSourceId = dataSourceId;
        }

        public override void Accept(IExpressionVisitor visitor)
        {
            Require.NotNull(visitor, "visitor");
            visitor.Visit(this);
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(DataSourceId))
            {
                return Value;
            }

            if (!String.IsNullOrEmpty(Value))
            {
                return "ds:" + DataSourceId + ":" + Value;
            }

            return "ds:" + DataSourceId;
        }
    }
}
