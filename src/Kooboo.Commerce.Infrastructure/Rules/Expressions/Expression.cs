﻿using Kooboo.Commerce.Rules.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Rules.Expressions
{
    /// <summary>
    /// Represents a node in the abstract syntax tree.
    /// </summary>
    public abstract class Expression
    {
        public abstract void Accept(IExpressionVisitor visitor);

        public static Expression Parse(string source)
        {
            return Parse(source, ComparisonOperatorManager.Instance.AllOperatorNamesAndAlias());
        }

        public static Expression Parse(string source, IEnumerable<string> registeredComparisonOperators)
        {
            return new Parser().Parse(source, registeredComparisonOperators);
        }
    }
}
