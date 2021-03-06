﻿using Kooboo.Web.Mvc.Grid2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kooboo.Commerce.Web.Areas.Commerce.Models.PaymentMethods.Grid2
{
    public class PaymentMethodRowModelGridItem : GridItem
    {
        public PaymentMethodRowModelGridItem(IGridModel gridModel, object dataItem, int dataIndex)
            : base(gridModel, dataItem, dataIndex)
        {
        }

        public override IHtmlString RenderItemContainerAtts()
        {
            var model = (PaymentMethodRowModel)DataItem;

            var cssClass = model.IsConfigurable ? "configurable" : "unconfigurable";
            cssClass += " " + (model.IsEnabled ? "enabled" : "disabled");

            return new HtmlString("class=\"" + cssClass + "\"");
        }
    }
}