﻿using PowerPointLabs.ActionFramework.Common.Attribute;
using PowerPointLabs.ActionFramework.Common.Interface;
using PowerPointLabs.TextCollection;

namespace PowerPointLabs.ActionFramework.Label.HighlightLab
{
    [ExportLabelRibbonId(TextCollection1.HighlightLabSettingsTag)]
    class HighlightLabSettingsLabelHandler : LabelHandler
    {
        protected override string GetLabel(string ribbonId)
        {
            return HighlightLabText.SettingsButtonLabel;
        }
    }
}
