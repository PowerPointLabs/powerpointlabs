﻿using PowerPointLabs.ActionFramework.Common.Attribute;
using PowerPointLabs.ActionFramework.Common.Interface;
using PowerPointLabs.TextCollection;

namespace PowerPointLabs.ActionFramework.CropLab
{
    [ExportLabelRibbonId(TextCollection1.CropToSlideTag)]
    class CropToSlideLabelHandler : LabelHandler
    {
        protected override string GetLabel(string ribbonId)
        {
            return CropLabText.CropToSlideButtonLabel;
        }
    }
}
