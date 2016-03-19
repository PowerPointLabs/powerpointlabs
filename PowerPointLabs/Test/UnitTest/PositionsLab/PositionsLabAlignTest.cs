﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PowerPointLabs.PositionsLab;
using PowerPointLabs.ResizeLab;

namespace Test.UnitTest.PositionsLab
{
    [TestClass]
    public class PositionsLabAlignTest : BasePositionsLabTest
    {
        private readonly Dictionary<string, ShapeProperties> _originalShapesProperties =
            new Dictionary<string, ShapeProperties>();
        private List<string> _shapeNames;

        private const int OriginalShapesSlideNo = 4;
        private const string UnrotatedRectangle = "Rectangle 3";
        private const string Oval = "Oval 4";
        private const string RotatedArrow = "Right Arrow 5";
        private const string RotatedRectangle = "Rectangle 6";

        //Results of Operations
        private const int AlignShapesLeftToSlideNo = 5;
        private const int AlignShapesRightToSlideNo = 6;
        private const int AlignShapesTopToSlideNo = 7;
        private const int AlignShapesBottomToSlideNo = 8;
        private const int AlignShapesHorizontalToSlideNo = 9;
        private const int AlignShapesVerticalToSlideNo = 10;
        private const int AlignShapesCenterToSlideNo = 11;

        private const int AlignShapesLeftToRefShapeNo = 13;
        private const int AlignShapesRightToRefShapeNo = 14;
        private const int AlignShapesTopToRefShapeNo = 15;
        private const int AlignShapesBottomToRefShapeNo = 16;
        private const int AlignShapesHorizontalToRefShapeNo = 17;
        private const int AlignShapesVerticalToRefShapeNo = 18;
        private const int AlignShapesCenterToRefShapeNo = 19;

        private const int AlignOneShapeLeftDefaultNo = 21;
        private const int AlignOneShapeRightDefaultNo = 22;
        private const int AlignOneShapeTopDefaultNo = 23;
        private const int AlignOneShapeBottomDefaultNo = 24;
        private const int AlignOneShapeHorizontalDefaultNo = 25;
        private const int AlignOneShapeVerticalDefaultNo = 26;
        private const int AlignOneShapeCenterDefaultNo = 27;

        private const int AlignShapesLeftDefaultNo = 28;
        private const int AlignShapesRightDefaultNo = 29;
        private const int AlignShapesTopDefaultNo = 30;
        private const int AlignShapesBottomDefaultNo = 31;
        private const int AlignShapesHorizontalDefaultNo = 32;
        private const int AlignShapesVerticalDefaultNo = 33;
        private const int AlignShapesCenterDefaultNo = 34;

        [TestMethod]
        protected override string GetTestingSlideName()
        {
            return "PositionsLab\\PositionsLabAlign.pptx";
        }

        [TestInitialize]
        public void TestInitialize()
        {
            PositionsLabMain.InitPositionsLab();

            _shapeNames = new List<string> { UnrotatedRectangle, Oval, RotatedArrow, RotatedRectangle };
            PpOperations.SelectSlide(OriginalShapesSlideNo);
            _originalShapesProperties.Clear();

            InitOriginalShapes(OriginalShapesSlideNo, _shapeNames, _originalShapesProperties);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            var shapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            RestoreShapes(shapes, _originalShapesProperties);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignLeftToSlide()
        {
            PositionsLabMain.AlignReferToSlide();
            _shapeNames = new List<string> { UnrotatedRectangle, Oval, RotatedArrow, RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            PositionsLabMain.AlignLeft(actualShapes);

            PpOperations.SelectSlide(AlignShapesLeftToSlideNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignRightToSlide()
        {
            PositionsLabMain.AlignReferToSlide();
            _shapeNames = new List<string> { UnrotatedRectangle, Oval, RotatedArrow, RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideWidth = Pres.PageSetup.SlideWidth;
            PositionsLabMain.AlignRight(actualShapes, slideWidth);

            PpOperations.SelectSlide(AlignShapesRightToSlideNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignTopToSlide()
        {
            PositionsLabMain.AlignReferToSlide();
            _shapeNames = new List<string> { UnrotatedRectangle, Oval, RotatedArrow, RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            PositionsLabMain.AlignTop(actualShapes);

            PpOperations.SelectSlide(AlignShapesTopToSlideNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignBottomToSlide()
        {
            PositionsLabMain.AlignReferToSlide();
            _shapeNames = new List<string> { UnrotatedRectangle, Oval, RotatedArrow, RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideHeight = Pres.PageSetup.SlideHeight;
            PositionsLabMain.AlignBottom(actualShapes, slideHeight);

            PpOperations.SelectSlide(AlignShapesBottomToSlideNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignHorizontalToSlide()
        {
            PositionsLabMain.AlignReferToSlide();
            _shapeNames = new List<string> { UnrotatedRectangle, Oval, RotatedArrow, RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideHeight = Pres.PageSetup.SlideHeight;
            PositionsLabMain.AlignHorizontalCenter(actualShapes, slideHeight);

            PpOperations.SelectSlide(AlignShapesHorizontalToSlideNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignVerticalToSlide()
        {
            PositionsLabMain.AlignReferToSlide();
            _shapeNames = new List<string> { UnrotatedRectangle, Oval, RotatedArrow, RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideWidth = Pres.PageSetup.SlideWidth;
            PositionsLabMain.AlignVerticalCenter(actualShapes, slideWidth);

            PpOperations.SelectSlide(AlignShapesVerticalToSlideNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignCenterToSlide()
        {
            PositionsLabMain.AlignReferToSlide();
            _shapeNames = new List<string> { UnrotatedRectangle, Oval, RotatedArrow, RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideHeight = Pres.PageSetup.SlideHeight;
            var slideWidth = Pres.PageSetup.SlideWidth;
            PositionsLabMain.AlignCenter(actualShapes, slideHeight, slideWidth);

            PpOperations.SelectSlide(AlignShapesCenterToSlideNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignLeftToRefShape()
        {
            PositionsLabMain.AlignReferToShape();
            _shapeNames = new List<string> { RotatedRectangle, UnrotatedRectangle, Oval, RotatedArrow };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            PositionsLabMain.AlignLeft(actualShapes);

            PpOperations.SelectSlide(AlignShapesLeftToRefShapeNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignRightToRefShape()
        {
            PositionsLabMain.AlignReferToShape();
            _shapeNames = new List<string> { RotatedRectangle, UnrotatedRectangle, Oval, RotatedArrow };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideWidth = Pres.PageSetup.SlideWidth;
            PositionsLabMain.AlignRight(actualShapes, slideWidth);

            PpOperations.SelectSlide(AlignShapesRightToRefShapeNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignTopToRefShape()
        {
            PositionsLabMain.AlignReferToShape();
            _shapeNames = new List<string> { RotatedRectangle, UnrotatedRectangle, Oval, RotatedArrow };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            PositionsLabMain.AlignTop(actualShapes);

            PpOperations.SelectSlide(AlignShapesTopToRefShapeNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignBottomToRefShape()
        {
            PositionsLabMain.AlignReferToShape();
            _shapeNames = new List<string> { RotatedRectangle, UnrotatedRectangle, Oval, RotatedArrow };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideHeight = Pres.PageSetup.SlideHeight;
            PositionsLabMain.AlignBottom(actualShapes, slideHeight);

            PpOperations.SelectSlide(AlignShapesBottomToRefShapeNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignHorizontalToRefShape()
        {
            PositionsLabMain.AlignReferToShape();
            _shapeNames = new List<string> { RotatedRectangle, UnrotatedRectangle, Oval, RotatedArrow };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideHeight = Pres.PageSetup.SlideHeight;
            PositionsLabMain.AlignHorizontalCenter(actualShapes, slideHeight);

            PpOperations.SelectSlide(AlignShapesHorizontalToRefShapeNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignVerticalToRefShape()
        {
            PositionsLabMain.AlignReferToShape();
            _shapeNames = new List<string> { RotatedRectangle, UnrotatedRectangle, Oval, RotatedArrow };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideWidth = Pres.PageSetup.SlideWidth;
            PositionsLabMain.AlignVerticalCenter(actualShapes, slideWidth);

            PpOperations.SelectSlide(AlignShapesVerticalToRefShapeNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignCenterToRefShape()
        {
            PositionsLabMain.AlignReferToShape();
            _shapeNames = new List<string> { RotatedRectangle, UnrotatedRectangle, Oval, RotatedArrow };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideHeight = Pres.PageSetup.SlideHeight;
            var slideWidth = Pres.PageSetup.SlideWidth;
            PositionsLabMain.AlignCenter(actualShapes, slideHeight, slideWidth);

            PpOperations.SelectSlide(AlignShapesCenterToRefShapeNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignOneLeftDefault()
        {
            PositionsLabMain.AlignReferToPowerpointDefaults();
            _shapeNames = new List<string> { RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            PositionsLabMain.AlignLeft(actualShapes);

            PpOperations.SelectSlide(AlignOneShapeLeftDefaultNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignOneRightDefault()
        {
            PositionsLabMain.AlignReferToPowerpointDefaults();
            _shapeNames = new List<string> { RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideWidth = Pres.PageSetup.SlideWidth;
            PositionsLabMain.AlignRight(actualShapes, slideWidth);

            PpOperations.SelectSlide(AlignOneShapeRightDefaultNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignOneTopDefault()
        {
            PositionsLabMain.AlignReferToPowerpointDefaults();
            _shapeNames = new List<string> { RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            PositionsLabMain.AlignTop(actualShapes);

            PpOperations.SelectSlide(AlignOneShapeTopDefaultNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignOneBottomDefault()
        {
            PositionsLabMain.AlignReferToPowerpointDefaults();
            _shapeNames = new List<string> { RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideHeight = Pres.PageSetup.SlideHeight;
            PositionsLabMain.AlignBottom(actualShapes, slideHeight);

            PpOperations.SelectSlide(AlignOneShapeBottomDefaultNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignOneHorizontalDefault()
        {
            PositionsLabMain.AlignReferToPowerpointDefaults();
            _shapeNames = new List<string> { RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideHeight = Pres.PageSetup.SlideHeight;
            PositionsLabMain.AlignHorizontalCenter(actualShapes, slideHeight);

            PpOperations.SelectSlide(AlignOneShapeHorizontalDefaultNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignOneVerticalDefault()
        {
            PositionsLabMain.AlignReferToPowerpointDefaults();
            _shapeNames = new List<string> { RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideWidth = Pres.PageSetup.SlideWidth;
            PositionsLabMain.AlignVerticalCenter(actualShapes, slideWidth);

            PpOperations.SelectSlide(AlignOneShapeVerticalDefaultNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignOneCenterDefault()
        {
            PositionsLabMain.AlignReferToPowerpointDefaults();
            _shapeNames = new List<string> { RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideHeight = Pres.PageSetup.SlideHeight;
            var slideWidth = Pres.PageSetup.SlideWidth;
            PositionsLabMain.AlignCenter(actualShapes, slideHeight, slideWidth);

            PpOperations.SelectSlide(AlignOneShapeCenterDefaultNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignLeftDefault()
        {
            PositionsLabMain.AlignReferToPowerpointDefaults();
            _shapeNames = new List<string> { UnrotatedRectangle, Oval, RotatedArrow, RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            PositionsLabMain.AlignLeft(actualShapes);

            PpOperations.SelectSlide(AlignShapesLeftDefaultNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignRightDefault()
        {
            PositionsLabMain.AlignReferToPowerpointDefaults();
            _shapeNames = new List<string> { UnrotatedRectangle, Oval, RotatedArrow, RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideWidth = Pres.PageSetup.SlideWidth;
            PositionsLabMain.AlignRight(actualShapes, slideWidth);

            PpOperations.SelectSlide(AlignShapesRightDefaultNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignTopDefault()
        {
            PositionsLabMain.AlignReferToPowerpointDefaults();
            _shapeNames = new List<string> { UnrotatedRectangle, Oval, RotatedArrow, RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            PositionsLabMain.AlignTop(actualShapes);

            PpOperations.SelectSlide(AlignShapesTopDefaultNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignBottomDefault()
        {
            PositionsLabMain.AlignReferToPowerpointDefaults();
            _shapeNames = new List<string> { UnrotatedRectangle, Oval, RotatedArrow, RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideHeight = Pres.PageSetup.SlideHeight;
            PositionsLabMain.AlignBottom(actualShapes, slideHeight);

            PpOperations.SelectSlide(AlignShapesBottomDefaultNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignHorizontalDefault()
        {
            PositionsLabMain.AlignReferToPowerpointDefaults();
            _shapeNames = new List<string> { UnrotatedRectangle, Oval, RotatedArrow, RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideHeight = Pres.PageSetup.SlideHeight;
            PositionsLabMain.AlignHorizontalCenter(actualShapes, slideHeight);

            PpOperations.SelectSlide(AlignShapesHorizontalDefaultNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignVerticalDefault()
        {
            PositionsLabMain.AlignReferToPowerpointDefaults();
            _shapeNames = new List<string> { UnrotatedRectangle, Oval, RotatedArrow, RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideWidth = Pres.PageSetup.SlideWidth;
            PositionsLabMain.AlignVerticalCenter(actualShapes, slideWidth);

            PpOperations.SelectSlide(AlignShapesVerticalDefaultNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }

        [TestMethod]
        [TestCategory("UT")]
        public void TestAlignCenterDefault()
        {
            PositionsLabMain.AlignReferToPowerpointDefaults();
            _shapeNames = new List<string> { UnrotatedRectangle, Oval, RotatedArrow, RotatedRectangle };
            var actualShapes = GetShapes(OriginalShapesSlideNo, _shapeNames);
            var slideHeight = Pres.PageSetup.SlideHeight;
            var slideWidth = Pres.PageSetup.SlideWidth;
            PositionsLabMain.AlignCenter(actualShapes, slideHeight, slideWidth);

            PpOperations.SelectSlide(AlignShapesCenterDefaultNo);
            var expectedShapes = PpOperations.SelectShapes(_shapeNames);

            CheckShapes(expectedShapes, actualShapes);
        }
    }
}
