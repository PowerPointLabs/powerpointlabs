﻿using System.Windows;

using PowerPointLabs.ActionFramework.Common.Attribute;
using PowerPointLabs.ActionFramework.Common.Extension;
using PowerPointLabs.ActionFramework.Common.Interface;

namespace PowerPointLabs.ActionFramework.Action.PasteLab
{
    [ExportActionRibbonId("PasteAndReplace", "PasteAndReplaceFreeform", "PasteAndReplacePicture")]
    class PasteLabReplaceActionHandler : PasteLabActionHandler
    {
        protected override void ExecutePasteAction(string ribbonId, bool isClipboardEmpty)
        {
            var presentation = this.GetCurrentPresentation();
            var slide = this.GetCurrentSlide();
            var selection = this.GetCurrentSelection();

            PowerPointLabs.PasteLab.PasteLabMain.PasteAndReplace(presentation, slide, isClipboardEmpty, selection);
        }
    }
}