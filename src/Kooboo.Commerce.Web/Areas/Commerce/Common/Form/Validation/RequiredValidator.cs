﻿using Kooboo.CMS.Common.Runtime.Dependency;
using Kooboo.Commerce.EAV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kooboo.Commerce.Web.Form.Validation
{
    [Dependency(typeof(IValidator), Key = "Required")]
    public class RequiredValidator : IValidator
    {
        public string Name
        {
            get
            {
                return "Required";
            }
        }

        public IEnumerable<System.Web.Mvc.ModelClientValidationRule> GetClientValidationRules(CustomField field, FieldValidationRule rule)
        {
            yield return new ModelClientValidationRequiredRule(rule.ErrorMessage);
        }
    }
}