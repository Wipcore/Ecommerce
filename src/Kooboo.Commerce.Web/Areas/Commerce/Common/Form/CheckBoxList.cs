﻿using Kooboo.CMS.Common.Runtime.Dependency;
using Kooboo.Commerce.EAV;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Kooboo.Commerce.Web.Form
{
    [Dependency(typeof(IFormControl), Key = "CheckBoxList")]
    public class CheckBoxList : FormControlBase
    {
        public override string Name
        {
            get
            {
                return "CheckBoxList";
            }
        }

        protected override string TagName
        {
            get
            {
                return "ul";
            }
        }

        public override string ValueBindingName
        {
            get
            {
                return "checkboxlist";
            }
        }

        protected override void BuildControl(System.Web.Mvc.TagBuilder builder, CustomField field, string value, object htmlAttributes, System.Web.Mvc.ViewContext viewContext)
        {
            builder.AddCssClass("form-list");

            if (!String.IsNullOrWhiteSpace(field.SelectionItems))
            {
                var items = JsonConvert.DeserializeObject<List<SelectionListItem>>(field.SelectionItems);
                var itemsHtml = new StringBuilder();

                for (var i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    itemsHtml.AppendLine("<li>");

                    var checkboxId = field.Name + "_" + i;
                    var checkbox = new TagBuilder("input");
                    checkbox.MergeAttribute("id", checkboxId);
                    checkbox.MergeAttribute("type", "checkbox");
                    checkbox.MergeAttribute("name", field.Name);
                    checkbox.MergeAttribute("value", item.Value);

                    var label = new TagBuilder("label");
                    label.InnerHtml = item.Key;
                    label.AddCssClass("inline");
                    label.MergeAttribute("for", checkboxId);

                    itemsHtml.AppendLine(checkbox.ToString(TagRenderMode.SelfClosing));
                    itemsHtml.AppendLine(label.ToString());

                    itemsHtml.AppendLine("</li>");
                }

                builder.InnerHtml = itemsHtml.ToString();
            }

            base.BuildControl(builder, field, value, htmlAttributes, viewContext);
        }
    }
}