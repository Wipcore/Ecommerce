﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.Rules
{
    public interface IParameter
    {
        string Name { get; }

        Type ModelType { get; }

        Type ValueType { get; }

        IEnumerable<IComparisonOperator> SupportedOperators { get; }

        object GetValue(object model);
    }
}
