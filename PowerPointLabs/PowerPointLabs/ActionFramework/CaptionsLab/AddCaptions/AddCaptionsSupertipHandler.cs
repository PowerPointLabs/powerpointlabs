﻿using PowerPointLabs.ActionFramework.Common.Attribute;
using PowerPointLabs.ActionFramework.Common.Interface;
using PowerPointLabs.TextCollection;

namespace PowerPointLabs.ActionFramework.CaptionsLab
{
    [ExportSupertipRibbonId(TextCollection1.AddCaptionsTag)]
    class AddCaptionsSupertipHandler : SupertipHandler
    {
        protected override string GetSupertip(string ribbonId)
        {
            return CaptionsLabText.AddCaptionsButtonSupertip;
        }
    }
}
