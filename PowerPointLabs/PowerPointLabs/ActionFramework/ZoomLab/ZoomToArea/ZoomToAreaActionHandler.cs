﻿using PowerPointLabs.ActionFramework.Common.Attribute;
using PowerPointLabs.ActionFramework.Common.Extension;
using PowerPointLabs.ActionFramework.Common.Interface;
using PowerPointLabs.Models;
using PowerPointLabs.TextCollection;
using PowerPointLabs.Utils;
using PowerPointLabs.ZoomLab;

namespace PowerPointLabs.ActionFramework.ZoomLab
{
    [ExportActionRibbonId(ZoomLabText.ZoomToAreaTag)]
    class ZoomToAreaActionHandler : ActionHandler
    {
        protected override void ExecuteAction(string ribbonId)
        {
            this.StartNewUndoEntry();
            PowerPointPresentation pres = this.GetCurrentPresentation();
            PowerPointSlide slide = this.GetCurrentSlide();

            ClipboardUtil.RestoreClipboardAfterAction(() =>
            {
                ZoomToArea.AddZoomToArea();
                return ClipboardUtil.ClipboardRestoreSuccess;
            }, pres, slide);
        }
    }
}
