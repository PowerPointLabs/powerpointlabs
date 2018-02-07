﻿using PowerPointLabs.ActionFramework.Common.Attribute;
using PowerPointLabs.CropLab;
using PowerPointLabs.TextCollection;

namespace PowerPointLabs.ActionFramework.SaveLab
{
    [ExportActionRibbonId(SaveLabText.SavePresentationsButtonTag)]
    class SaveLabButtonActionHandler : Common.Interface.ActionHandler
    {
        protected override void ExecuteAction(string ribbonId)
        {
            // Save action here
        }
    }
}
