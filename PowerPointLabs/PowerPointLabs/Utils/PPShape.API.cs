using System;
using Microsoft.Office.Core;
using System.Drawing;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace PowerPointLabs.Utils
{
    public partial class PPShape
    {
        private readonly PowerPoint.Shape _shape;
        private float _absoluteWidth;
        private float _absoluteHeight;
        private float _rotatedVisualLeft;
        private float _rotatedVisualTop;
        private float _originalRotation;

        public PPShape(PowerPoint.Shape shape, bool redefineBoundingBox = true)
        {
            _shape = shape;
            _originalRotation = _shape.Rotation;

            if (redefineBoundingBox)
            {
                ConvertToFreeform();
            }

            UpdateAbsoluteWidth();
            UpdateAbsoluteHeight();

            UpdateTop();
            UpdateLeft();
        }

        #region Properties

        /// <summary>
        /// Return or set the name of the specified shape.
        /// </summary>
        public string Name
        {
            get { return _shape.Name; }
            set { _shape.Name = value; }
        }

        /// <summary>
        /// Return a 64-bit signed integer that identifies the PPshape. Read-only.
        /// </summary>
        public int Id => _shape.Id;

        /// <summary>
        /// Return or set the width of the specified shape.
        /// </summary>
        public float ShapeWidth
        {
            get { return _shape.Width; }
            set
            {
                _shape.Width = value;
                UpdateAbsoluteWidth();
            }
        }

        /// <summary>
        /// Return or set the height of the specified shape.
        /// </summary>
        public float ShapeHeight
        {
            get { return _shape.Height; }
            set
            {
                _shape.Height = value;
                UpdateAbsoluteHeight();
            }
        }

        /// <summary>
        /// Return or set the absolute width of rotated shape.
        /// </summary>
        public float AbsoluteWidth
        {
            get { return _absoluteWidth; }
            set
            {
                _absoluteWidth = value;
                
                if (_shape.LockAspectRatio == MsoTriState.msoTrue)
                {
                    SetToAbsoluteWidthAspectRatio();
                }
                else
                {
                    SetToAbsoluteDimension();
                }     
            }
        }

        /// <summary>
        /// Return or set the absolute height of rotated shape.
        /// </summary>
        public float AbsoluteHeight
        {
            get { return _absoluteHeight; }
            set
            {
                _absoluteHeight = value;

                if (_shape.LockAspectRatio == MsoTriState.msoTrue)
                {
                    SetToAbsoluteHeightAspectRatio();
                }
                else
                {
                    SetToAbsoluteDimension();
                }
            }
        }

        /// <summary>
        /// Return or set the shape type for the specified Shape object,
        /// which must represent an AutoShape other than a line, freeform drawing, or connector.
        /// Read/write.
        /// </summary>
        public MsoAutoShapeType AutoShapeType
        {
            get { return _shape.AutoShapeType; }
            set { _shape.AutoShapeType = value; }
        }

        /// <summary>
        /// Return a point that represents the visual center of the shape.
        /// </summary>
        public PointF VisualCenter
        {
            get
            {
                var centerPoint = new PointF
                {
                    X = _rotatedVisualLeft + _absoluteWidth/2,
                    Y = _rotatedVisualTop + _absoluteHeight/2
                };
                return centerPoint;
            }
        }

        /// <summary>
        /// Return a point that represents the visual top left of the shape's bounding box after rotation.
        /// </summary>
        public PointF VisualTopLeft => new PointF
        {
            X = _rotatedVisualLeft,
            Y = _rotatedVisualTop
        };

        /// <summary>
        /// Return a point that represents the visual top center of the shape's bounding box after rotation.
        /// </summary>
        public PointF VisualTopCenter => new PointF
        {
            X = _rotatedVisualLeft + _absoluteWidth / 2,
            Y = _rotatedVisualTop
        };

        /// <summary>
        /// Return a point that represents the visual top right of the shape's bounding box after rotation.
        /// </summary>
        public PointF VisualTopRight => new PointF
        {
            X = _rotatedVisualLeft + _absoluteWidth,
            Y = _rotatedVisualTop
        };

        /// <summary>
        /// Return a point that represents the visual middle left of the shape's bounding box after rotation.
        /// </summary>
        public PointF VisualMiddleLeft => new PointF
        {
            X = _rotatedVisualLeft,
            Y = _rotatedVisualTop + _absoluteHeight / 2
        };

        /// <summary>
        /// Return a point that represents the visual middle right of the shape's bounding box after rotation.
        /// </summary>
        public PointF VisualMiddleRight => new PointF
        {
            X = _rotatedVisualLeft + _absoluteWidth,
            Y = _rotatedVisualTop + _absoluteHeight / 2
        };

        /// <summary>
        /// Return a point that represents the visual bottom left of the shape's bounding box after rotation.
        /// </summary>
        public PointF VisualBottomLeft => new PointF
        {
            X = _rotatedVisualLeft,
            Y = _rotatedVisualTop + _absoluteHeight
        };

        /// <summary>
        /// Return a point that represents the visual bottom center of the shape's bounding box after rotation.
        /// </summary>
        public PointF VisualBottomCenter => new PointF
        {
            X = _rotatedVisualLeft + _absoluteWidth / 2,
            Y = _rotatedVisualTop + _absoluteHeight
        };

        /// <summary>
        /// Return a point that represents the visual bottom right of the shape's bounding box after rotation.
        /// </summary>
        public PointF VisualBottomRight => new PointF
        {
            X = _rotatedVisualLeft + _absoluteWidth,
            Y = _rotatedVisualTop + _absoluteHeight
        };

        /// <summary>
        /// Return or set a single-precision floating-point number that represents the 
        /// distance from the left most point of the shape to the left edge of the slide.
        /// </summary>
        public float VisualLeft
        {
            get { return _rotatedVisualLeft; }
            set
            {
                _rotatedVisualLeft = value; 
                SetLeft();
            }
        }

        /// <summary>
        /// Return or set a single-precision floating-point number that represents the 
        /// distance from the top most point of the shape to the top edge of the slide.
        /// </summary>
        public float VisualTop
        {
            get { return _rotatedVisualTop; }
            set
            {
                _rotatedVisualTop = value;
                SetTop();
            }
        }

        /// <summary>
        /// Return or set the degrees of specified shape is rotated around the z-axis. 
        /// Read/write.
        /// </summary>
        public float ShapeRotation
        {
            get { return _originalRotation; }
            set { _originalRotation = value; }
        }

        /// <summary>
        /// Return or set the degrees of specified shape's bounding box is rotated around the z-axis. 
        /// Read/write.
        /// </summary>
        public float BoxRotation
        {
            get { return _shape.Rotation; }
            set
            {
                _shape.Rotation = value;
                ConvertToFreeform();
                UpdateAbsoluteHeight();
                UpdateAbsoluteWidth();
                UpdateLeft();
                UpdateTop();
            }
        }

        /// <summary>
        /// Returns the position of the specified shape in the z-order. Read-only.
        /// </summary>
        public int ZOrderPosition => _shape.ZOrderPosition;

        #endregion

        #region Functions

        /// <summary>
        /// Delete the specified Shape object.
        /// </summary>
        public void Delete()
        {
            _shape.Delete();
        }

        /// <summary>
        /// Create a duplicate of the specified Shape object and return a new shape.
        /// </summary>
        /// <returns></returns>
        public PPShape Duplicate()
        {
            var newShape = new PPShape(_shape.Duplicate()[1]) {Name = _shape.Name + "Copy"};
            return newShape;
        }

        /// <summary>
        /// Moves the specified shape horizontally by the specified number of points.
        /// </summary>
        /// <param name="value">Number of points from left of slide</param>
        public void IncrementLeft(float value)
        {
            _shape.IncrementLeft(value);
            UpdateLeft();
        }

        /// <summary>
        /// Moves the specified shape vertically by the specified number of points.
        /// </summary>
        /// <param name="value">Number of points from top of slide</param>
        public void IncrementTop(float value)
        {
            _shape.IncrementTop(value);
            UpdateTop();
        }

        /// <summary>
        /// Flip the specified shape around its horizontal or vertical axis.
        /// </summary>
        /// <param name="msoFlipCmd"></param>
        public void Flip(MsoFlipCmd msoFlipCmd)
        {
            _shape.Flip(msoFlipCmd);
        }

        /// <summary>
        /// Select the specified object.
        /// </summary>
        /// <param name="replace"></param>
        public void Select(MsoTriState replace)
        {
            _shape.Select(replace);
        }

        /// <summary>
        /// Reset the nodes to corresponding original rotation.
        /// </summary>
        public void ResetNodes()
        {
            if (_shape.Type != MsoShapeType.msoFreeform || _shape.Nodes.Count < 1) return;

            var isSecondOrFourthQuadrant = (_originalRotation >= 90 && _originalRotation < 180) ||
                                         (_originalRotation >= 270 && _originalRotation < 360);

            var rotation = GetStandardizedRotation(_originalRotation%90);
            var centerLeft = VisualCenter.X;
            var centerTop = VisualCenter.Y;

            for (int i = 1; i <= _shape.Nodes.Count; i++)
            {
                var node = _shape.Nodes[i];
                var point = node.Points;
                var oldX = point[1, 1];
                var oldY = point[1, 2];
                var newX = oldY*Math.Sin(rotation) + oldX*Math.Cos(rotation);
                var newY = oldY*Math.Cos(rotation) - oldX*Math.Sin(rotation);

                if (isSecondOrFourthQuadrant)
                {
                    newX = oldY * Math.Cos(rotation) - oldX * Math.Sin(rotation);
                    newY = oldY * Math.Sin(rotation) + oldX * Math.Cos(rotation);
                }

                _shape.Nodes.SetPosition(i, newX, newY);
            }

            _shape.Rotation = _originalRotation;

            UpdateAbsoluteWidth();
            UpdateAbsoluteHeight();

            VisualLeft = centerLeft - _absoluteWidth/2;
            VisualTop = centerTop - _absoluteHeight/2;
        }

        #endregion
    }
}
