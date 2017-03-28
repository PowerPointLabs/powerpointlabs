﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PowerPointLabs.SyncLab.ObjectFormats;

namespace Test.UnitTest.SyncLab
{
    [TestClass]
    public class SyncLabFontTest : BaseSyncLabTest
    {
        private const int OriginalShapesSlideNo = 15;
        private const string CopyFromSmallShape = "CopyFromSmall";
        private const string CopyFromLargeShape = "CopyFromLarge";
        private const string CopyToShape = "Rectangle 3";

        //Results of Operations
        private const int SyncFontFamilySlideNo = 16;
        private const int SyncFontSizeSlideNo = 17;
        private const int SyncFontFillSlideNo = 18;
        private const int SyncOneFontStyleSlideNo = 19;
        private const int SyncAllFontStyleSlideNo = 20;

        [TestMethod]
        [TestCategory("UT")]
        public void TestSyncFontFamily()
        {
            var formatShape = GetShape(OriginalShapesSlideNo, CopyFromLargeShape);

            var newShape = GetShape(OriginalShapesSlideNo, CopyToShape);
            FontFormat.SyncFormat(formatShape, newShape);

            CompareSlides(OriginalShapesSlideNo, SyncFontFamilySlideNo);
            CheckFontStyle(OriginalShapesSlideNo, SyncFontFamilySlideNo);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestSyncFontSize()
        {
            var formatShape = GetShape(OriginalShapesSlideNo, CopyFromLargeShape);

            var newShape = GetShape(OriginalShapesSlideNo, CopyToShape);
            FontSizeFormat.SyncFormat(formatShape, newShape);

            CompareSlides(OriginalShapesSlideNo, SyncFontSizeSlideNo);
            CheckFontStyle(OriginalShapesSlideNo, SyncFontSizeSlideNo);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestSyncFontFill()
        {
            var formatShape = GetShape(OriginalShapesSlideNo, CopyFromLargeShape);

            var newShape = GetShape(OriginalShapesSlideNo, CopyToShape);
            FontColorFormat.SyncFormat(formatShape, newShape);

            CompareSlides(OriginalShapesSlideNo, SyncFontFillSlideNo);
            CheckFontStyle(OriginalShapesSlideNo, SyncFontFillSlideNo);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestSyncOneFontStyle()
        {
            var formatShape = GetShape(OriginalShapesSlideNo, CopyFromLargeShape);

            var newShape = GetShape(OriginalShapesSlideNo, CopyToShape);
            FontStyleFormat.SyncFormat(formatShape, newShape);

            CheckFontStyle(OriginalShapesSlideNo, SyncOneFontStyleSlideNo);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestSyncAllFontStyle()
        {
            var formatShape = GetShape(OriginalShapesSlideNo, CopyFromSmallShape);

            var newShape = GetShape(OriginalShapesSlideNo, CopyToShape);
            FontStyleFormat.SyncFormat(formatShape, newShape);

            CheckFontStyle(OriginalShapesSlideNo, SyncAllFontStyleSlideNo);
        }

        //Changes in font style are too minute for CompareSlide to detect so we need to chek them manually
        protected void CheckFontStyle(int actualShapesSlideNo, int expectedShapesSlideNo)
        {
            var actualShape = GetShape(actualShapesSlideNo, CopyToShape);
            var expectedShape = GetShape(expectedShapesSlideNo, CopyToShape);

            var actualFont = actualShape.TextFrame.TextRange.Font;
            var expectedFont = expectedShape.TextFrame.TextRange.Font;

            Assert.IsTrue(actualFont.Bold == expectedFont.Bold
                && actualFont.Italic == expectedFont.Italic
                && actualFont.Underline == expectedFont.Underline,
                "Font Style does not match expected font style. Expected bold: " + expectedFont.Bold
                    + ", italic: " + expectedFont.Italic + ", underline: " + expectedFont.Underline
                    + ". Actual bold: " + actualFont.Bold + ", italic: " + actualFont.Italic + ", underline: "
                    + actualFont.Underline);
        }
    }
}
