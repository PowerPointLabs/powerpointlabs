﻿using PowerPointLabs.ActionFramework.Common.Attribute;
using PowerPointLabs.ActionFramework.Common.Interface;
using PowerPointLabs.TextCollection;

namespace PowerPointLabs.ActionFramework.NarrationsLab
{
    [ExportLabelRibbonId(TextCollection1.NarrationsLabSettingsTag)]
    class NarrationsLabSettingsLabelHandler : LabelHandler
    {
        protected override string GetLabel(string ribbonId)
        {
            return NarrationsLabText.NarrationsLabSettingsButtonLabel;
        }
    }
}
