﻿using Kooboo.Commerce.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kooboo.Commerce.Web.Areas.Commerce.Models.Activities
{
    public class ActivityModel
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool AllowAsyncExecution { get; set; }

        public string EditorVirtualPath { get; set; }

        public ActivityModel() { }

        public ActivityModel(IActivity activity, ActivityRule rule, AttachedActivityInfo attachedActivityInfo)
        {
            Name = activity.Name;
            DisplayName = activity.DisplayName;
            AllowAsyncExecution = activity.AllowAsyncExecution;

            if (activity is IHasCustomActivityParameterEditor)
            {
                EditorVirtualPath = ((IHasCustomActivityParameterEditor)activity).GetEditorVirtualPath(rule, attachedActivityInfo);
            }
            else if (activity.Parameters != null && activity.Parameters.Any())
            {
                EditorVirtualPath = "~/Areas/Commerce/Views/Activity/_DefaultParameterEditor.cshtml";
            }
        }
    }
}