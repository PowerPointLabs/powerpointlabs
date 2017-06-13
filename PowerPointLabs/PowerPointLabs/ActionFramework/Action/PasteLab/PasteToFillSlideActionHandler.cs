﻿using Microsoft.Office.Interop.PowerPoint;

using PowerPointLabs.ActionFramework.Common.Attribute;
using PowerPointLabs.Models;
using PowerPointLabs.PasteLab;

namespace PowerPointLabs.ActionFramework.Action.PasteLab
{
    [ExportActionRibbonId(
        "PasteToFillSlideMenuFrame",
        "PasteToFillSlideMenuShape",
        "PasteToFillSlideMenuLine",
        "PasteToFillSlideMenuFreeform",
        "PasteToFillSlideMenuPicture",
        "PasteToFillSlideMenuGroup",
        "PasteToFillSlideMenuInk",
        "PasteToFillSlideMenuVideo",
        "PasteToFillSlideMenuChart",
        "PasteToFillSlideMenuTable",
        "PasteToFillSlideMenuTableWhole",
        "PasteToFillSlideMenuSmartArtBackground",
        "PasteToFillSlideMenuSmartArtEditSmartArt",
        "PasteToFillSlideMenuSmartArtEditText")]
    class PasteToFillSlideActionHandler : PasteLabActionHandler
    {
        protected override ShapeRange ExecutePasteAction(string ribbonId, PowerPointPresentation presentation, PowerPointSlide slide,
                                                        ShapeRange selectedShapes, ShapeRange selectedChildShapes)
        {
            ShapeRange pastingShapes = slide.Shapes.Paste();
            PasteToFillSlide.Execute(slide, pastingShapes, presentation.SlideWidth, presentation.SlideHeight);
            return null;
        }
    }
}
