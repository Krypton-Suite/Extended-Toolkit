﻿using System.Drawing;
using System.Drawing.Drawing2D;

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    /// <summary>
    /// Code from: https://github.com/aalitor/AltoControls/blob/on-development/AltoControls/Helpers/RoundedRectangleF.cs
    /// </summary>
    internal class RoundedRectangleF
    {
        #region Variables
        private float _x, _y, _width, _height, _radius;

        private GraphicsPath _graphicsPath;

        private Point _location;
        #endregion

        #region Properties
        public GraphicsPath Path => _graphicsPath;

        public RectangleF Rect => new RectangleF(_x, _y, _width, _height);

        public float Radius { get => _radius; set => _radius = value; }
        #endregion

        #region Constructors
        public RoundedRectangleF(float width, float height, float radius, float x = 0, float y = 0)
        {

            _location = new Point(0, 0);

            _radius = radius;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _graphicsPath = new GraphicsPath();
            if (radius <= 0)
            {
                _graphicsPath.AddRectangle(new RectangleF(x, y, width, height));
                return;
            }
            RectangleF upperLeftRect = new RectangleF(x, y, 2 * radius, 2 * radius);
            RectangleF upperRightRect = new RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius);
            RectangleF lowerLeftRect = new RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius);
            RectangleF lowerRightRect = new RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius);

            _graphicsPath.AddArc(upperLeftRect, 180, 90);
            _graphicsPath.AddArc(upperRightRect, 270, 90);
            _graphicsPath.AddArc(lowerRightRect, 0, 90);
            _graphicsPath.AddArc(lowerLeftRect, 90, 90);
            _graphicsPath.CloseAllFigures();

        }
        #endregion
    }
}