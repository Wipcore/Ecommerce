﻿using Kooboo.CMS.Common.Runtime.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kooboo.Commerce.Web.Form
{
    [Dependency(typeof(IFormControl), Key = "Number")]
    public class Number : InputControl
    {
        protected override string Type
        {
            get
            {
                return "text";
            }
        }

        public override string Name
        {
            get
            {
                return "Number";
            }
        }
    }
}