﻿using System.Windows.Forms;

using Microsoft.Office.Interop.PowerPoint;

using PowerPointLabs.ActionFramework.Common.Attribute;
using PowerPointLabs.Models;
using PowerPointLabs.PasteLab;

namespace PowerPointLabs.ActionFramework.Action.PasteLab
{
    [ExportActionRibbonId(
        "ReplaceWithClipboardMenuShape",
        "ReplaceWithClipboardMenuLine",
        "ReplaceWithClipboardMenuFreeform",
        "ReplaceWithClipboardMenuPicture",
        "ReplaceWithClipboardMenuGroup",
        "ReplaceWithClipboardMenuInk",
        "ReplaceWithClipboardMenuVideo",
        "ReplaceWithClipboardMenuChart",
        "ReplaceWithClipboardMenuTable",
        "ReplaceWithClipboardMenuTableWhole",
        "ReplaceWithClipboardMenuSmartArtBackground")]
    class ReplaceWithClipboardActionHandler : PasteLabActionHandler
    {
        protected override ShapeRange ExecutePasteAction(string ribbonId, PowerPointPresentation presentation, PowerPointSlide slide,
                                                        ShapeRange selectedShapes, ShapeRange selectedChildShapes)
        {
            if (selectedShapes.Count <= 0)
            {
                MessageBox.Show("Please select at least one shape.", "Error");
                return null;
            }
            
            ShapeRange pastingShapes = slide.Shapes.Paste();
            return ReplaceWithClipboard.Execute(presentation, slide, selectedShapes, selectedChildShapes, pastingShapes);
        }
    }
}