﻿using System.Drawing;
using PowerPointLabs.ActionFramework.Common.Attribute;
using PowerPointLabs.ActionFramework.Common.Interface;

namespace PowerPointLabs.ActionFramework.Image
{
    [ExportImageRibbonId("AddToShapesLabMenuShape", "AddToShapesLabMenuLine", "AddToShapesLabMenuPicture",
                        "AddToShapesLabMenuChart", "AddToShapesLabMenuTable", "AddToShapesLabMenuGroup",
                        "AddToShapesLabMenuFreeform", "AddToShapesLabMenuInk", "AddToShapesLabMenuSmartArt")]
    class AddShapeImageHandler : ImageHandler
    {
        protected override Bitmap GetImage(string ribbonId)
        {
            return new Bitmap(Properties.Resources.AddToCustomShapes);
        }
    }
}