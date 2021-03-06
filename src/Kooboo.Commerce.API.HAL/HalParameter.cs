﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kooboo.Commerce.API.HAL
{
    public class HalParameter
    {
        public HalParameter()
        {

        }

        public HalParameter (string name, Type parameterType, bool required = false)
        {
            Name = name;
            ParameterType = parameterType;
            Required = required;
        }

        public string Name { get; set; }
        public Type ParameterType { get; set; }
        public bool Required { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public static string NormailizeParameterName(string typeName, string paraName)
        {
            return string.Format("{0}.{1}", typeName, paraName).ToLower();
        }
    }
}
