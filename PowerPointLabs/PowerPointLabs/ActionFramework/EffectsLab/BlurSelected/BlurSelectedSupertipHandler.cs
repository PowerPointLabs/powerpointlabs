﻿using PowerPointLabs.ActionFramework.Common.Attribute;
using PowerPointLabs.ActionFramework.Common.Interface;
using PowerPointLabs.TextCollection;

namespace PowerPointLabs.ActionFramework.EffectsLab
{
    [ExportSupertipRibbonId(TextCollection1.BlurSelectedMenuId)]
    class BlurSelectedSupertipHandler : SupertipHandler
    {
        protected override string GetSupertip(string ribbonId)
        {
            return EffectsLabText.BlurSelectedSupertip;
        }
    }
}
