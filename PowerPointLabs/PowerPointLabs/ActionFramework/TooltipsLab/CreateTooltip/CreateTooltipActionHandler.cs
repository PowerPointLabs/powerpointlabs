﻿using Microsoft.Office.Interop.PowerPoint;
using PowerPointLabs.ActionFramework.Common.Attribute;
using PowerPointLabs.ActionFramework.Common.Extension;
using PowerPointLabs.ActionFramework.Common.Interface;
using PowerPointLabs.AnimationLab;
using PowerPointLabs.Models;
using PowerPointLabs.TextCollection;
using PowerPointLabs.TooltipsLab;
using PowerPointLabs.Utils;

namespace PowerPointLabs.ActionFramework.TooltipsLab
{
    [ExportActionRibbonId(TooltipsLabText.CreateTooltipTag)]
    class CreateTooltipActionHandler : ActionHandler
    {
        protected override void ExecuteAction(string ribbonId)
        {
            Selection selection = this.GetCurrentSelection();
            PowerPointSlide currentSlide = this.GetCurrentSlide();

            if (!ShapeUtil.IsSelectionShape(selection))
            {
                return;
            }

            AttachTriggerAnimation.AddTriggerAnimation(currentSlide, selection);
        }
    }
}
